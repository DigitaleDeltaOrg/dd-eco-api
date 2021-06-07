using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace DD_ECO_FilterParser
{
	/// <summary>
	///   Main filter class. Parses a line into separate statements, and statements into fieldname, operator and value
	///   components.
	/// </summary>
	public sealed class FilterParser
	{
		#region Public

		public List<Condition> Conditions { private set; get; }

		public bool IsValid { set; get; }

		private char ComponentSeparator { get; }

		private char ComparerSeparator { get; }

		private string DateFormat { get; }

		public List<FieldDefinition> Fields { get; }

		public List<DdEcoParserError> Errors { get; }
		public string? Title { set; get; }

		/// <summary>
		///   Construct and configure the parser.
		/// </summary>
		/// <param name="fields">List of fields definitions allowed by the parser. </param>
		/// <param name="comparerSeparator">Separator character for statements. Defaults to ';'.</param>
		/// <param name="componentSeparator">Separator character for components. Defaults to ':'</param>
		/// <param name="dateFormat">Date format for parsing dates. Defaults to "yyyy-MM-dd".</param>
		public FilterParser(List<FieldDefinition> fields, char comparerSeparator = ';', char componentSeparator = ':', string dateFormat = "yyyy-MM-dd")
		{
			Fields             = fields;
			IsValid            = true;
			Conditions         = new();
			Errors             = new();
			ComponentSeparator = componentSeparator;
			ComparerSeparator  = comparerSeparator;
			DateFormat         = dateFormat;

			if (componentSeparator == comparerSeparator)
			{
				Errors.Add(new(ErrorType.Separator, string.Empty));
				IsValid = false;
			}

			if (string.IsNullOrWhiteSpace(DateFormat))
			{
				Errors.Add(new(ErrorType.DateFormatter, string.Empty));
				IsValid = false;
			}

			if (DateFormat.Contains("yyyy", StringComparison.InvariantCultureIgnoreCase) || DateFormat.Contains("MM", StringComparison.InvariantCultureIgnoreCase) || DateFormat.Contains("dd", StringComparison.InvariantCultureIgnoreCase))
			{
				return;
			}

			Errors.Add(new(ErrorType.DateFormatterDateFormat, string.Empty));
			IsValid = false;
		}

		/// <summary>
		///   Parse the specified line.
		/// </summary>
		/// <param name="filter">Filter to be parsed.</param>
		public void Parse(string? filter)
		{
			IsValid = true;
			Conditions = new();
			if (string.IsNullOrWhiteSpace(filter))
			{
				return;
			}

			var filterParts = SplitLine(filter, ComparerSeparator).ToList();
			filterParts.ForEach(ParseStatement);

			var requiredFields = Fields.Where(a => a.Required).
			                            Select(a => a.FieldName);
			foreach (var requiredField in requiredFields)
			{
				if (Conditions.Any(a => a.FieldName == requiredField))
				{
					continue;
				}
				Errors.Add(new(ErrorType.Required, requiredField));
			}
		}

		#endregion Public

		#region Private

		/// <summary>
		///   Splits a test into parts, specified by the separator. Takes into account that the separator can be embedded in
		///   quotes.
		/// </summary>
		/// <param name="stringToSplit">The string to be split.</param>
		/// <param name="separator">The separator character.</param>
		/// <param name="allowQuoted"></param>
		/// <returns>List of strings.</returns>
		// <remarks>Improved and modernized version of: https://stackoverflow.com/a/31804981 </remarks>
		private static List<string> SplitLine(string stringToSplit, char separator, bool allowQuoted = false)
		{
			if (!allowQuoted)
			{
				return stringToSplit.Split(new[] {separator}, StringSplitOptions.RemoveEmptyEntries).ToList();
			}

			var characters = stringToSplit.ToCharArray();
			var returnValueList = new List<string>();
			var tempString = new StringBuilder();
			var blockUntilEndQuote = false;
			var blockUntilEndQuote2 = false;
			var characterCount = 0;
			foreach (var character in characters)
			{
				characterCount = ProcessCharacter(separator, characterCount, character, tempString, returnValueList, characters, ref blockUntilEndQuote2, ref blockUntilEndQuote);
			}

			return returnValueList;
		}

		private static int ProcessCharacter(char separator, int characterCount, char character, StringBuilder tempString, List<string> returnValueList, IReadOnlyCollection<char> characters, ref bool blockUntilEndQuote2, ref bool blockUntilEndQuote)
		{
			characterCount++;
			switch (character)
			{
				case '"' when !blockUntilEndQuote2:
					blockUntilEndQuote = !blockUntilEndQuote;
					break;

				case '\'' when !blockUntilEndQuote:
					blockUntilEndQuote2 = !blockUntilEndQuote2;
					break;
			}

			if (character != separator)
			{
				tempString.Append(character);
			}
			else
			{
				HandleSeparator(separator, character, tempString, returnValueList, blockUntilEndQuote2, blockUntilEndQuote);
			}

			if (characterCount != characters.Count)
			{
				return characterCount;
			}

			returnValueList.Add(tempString.ToString());
			tempString.Clear();
			return characterCount;
		}

		private static void HandleSeparator(char separator, char character, StringBuilder tempString, ICollection<string> returnValueList, bool blockUntilEndQuote2, bool blockUntilEndQuote)
		{
			if (character == separator && (blockUntilEndQuote || blockUntilEndQuote2))
			{
				tempString.Append(character);
			}
			else
			{
				returnValueList.Add(tempString.ToString());
				tempString.Clear();
			}
		}

		/// <summary>
		///   Parses a statement into components.
		/// </summary>
		/// <param name="parseValue">Value to parse.</param>
		private void ParseStatement(string parseValue)
		{
			var statement = new Condition();
			var parts = SplitLine(parseValue, ComponentSeparator); // Fast parser.
			if (parts.Count != 3)
			{
				// Everything OK.
				parts = SplitLine(parseValue, ComponentSeparator, true); // Retry with the slow (embed-enabled) parser.
			}

			if (parts.Count != 3) // Not three parts. Special case.
			{
				statement.Errors.Add(new(ErrorType.InvalidSyntax, parseValue));
				Conditions.Add(statement);
				Errors.AddRange(statement.Errors);
				IsValid = false;
				return;
			}

			// The parts are:
			// part[0]: parametername
			// part[1]: operator
			// part[2]: value
			var parameter = parts[0].ToLowerInvariant().Trim();
			statement.FieldName = parameter;
			if (Fields.All(field => !string.Equals(field.FieldName, parameter, StringComparison.CurrentCultureIgnoreCase)))
			{
				statement.Comparers = Comparer.Unknown;
				statement.Errors.Add(new(ErrorType.UnknownField, parseValue));
				Conditions.Add(statement);
				Errors.AddRange(statement.Errors);
				IsValid = false;
				return;
			}

			var fieldDefinition = Fields.Single(field => string.Equals(field.FieldName, parameter, StringComparison.CurrentCultureIgnoreCase));
			// Extract the operator.
			var @operator = ParseOperator(parts[1].ToUpperInvariant());
			statement.Comparers = @operator;
			if (@operator == Comparer.Unknown)
			{
				statement.Errors.Add(new(ErrorType.UnknownOperator, parseValue));
				Conditions.Add(statement);
				Errors.AddRange(statement.Errors);
				IsValid = false;
				return;
			}

			if (fieldDefinition.ComparerDataTypes.All(operatorDataType => operatorDataType.Comparer != @operator))
			{
				statement.Errors.Add(new(ErrorType.InvalidOperatorForField, parseValue));
				Conditions.Add(statement);
				Errors.AddRange(statement.Errors);
				IsValid = false;
				return;
			}

			var type = fieldDefinition.ComparerDataTypes.Single(operatorDataType => operatorDataType.Comparer == @operator).DataType;
			// Parse the value.
			var error = ParseValue(parts[2], type, statement);
			if (error != ErrorType.None)
			{
				statement.Errors.Add(new(error, parseValue));
				Conditions.Add(statement);
				Errors.AddRange(statement.Errors);
				IsValid = false;
				return;
			}

			Errors.AddRange(statement.Errors);
			Conditions.Add(statement);
		}

		private static bool HasListDuplicates<T>(IEnumerable<T> list)
		{
			return list.GroupBy(item => item).Where(item => item.Count() > 1).Select(item => item.Key).ToList().Count > 0;
		}

		/// <summary>
		///   Parses a value, based on data type.
		/// </summary>
		/// <param name="value">Value to be parsed.</param>
		/// <param name="dataType">The Digital Delta Data Type for the statement.</param>
		/// <param name="conditions">The processed statement</param>
		/// <returns>Error type</returns>
		/// <remarks>Uses the Newtonsoft JsonConvertor to parse the value.</remarks>
		private ErrorType ParseValue(string value, DataType dataType, Condition conditions)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return ErrorType.InvalidValue;
			}

			try
			{
				switch (dataType)
				{
					case DataType.StringType:
					{
						return ProcessStringType(value, conditions);
					}

					case DataType.DateType:
					{
						return ProcessDateType(value, conditions);
					}

					case DataType.NumericType:
					{
						return ProcessNumericType(value, conditions);
					}

					case DataType.ArrayOfStringType:
					{
						return ProcessArrayOfStringType(value, conditions);
					}

					case DataType.ArrayOfNumericType:
					{
						return ProcessArrayOfNumericType(value, conditions);
					}
					
					case DataType.Unsupported:
						break;
					
					default:
						Errors.Add(new(ErrorType.InvalidDataType, dataType.ToString()));
						break;
				}
			}
			catch (Exception)
			{
				return ErrorType.InvalidValue;
			}

			return ErrorType.InvalidValue;
		}
		
		private static ErrorType ProcessArrayOfNumericType(string value, Condition conditions)
		{
			var result = JsonSerializer.Deserialize<List<decimal>>(value);
			if (result == null)
			{
				return ErrorType.InvalidValue;
			}
			conditions.ArrayOfNumericValues = result;
			conditions.ParameterDataType = DataType.ArrayOfNumericType;
			return HasListDuplicates(conditions.ArrayOfNumericValues)
				       ? ErrorType.DuplicatesInList
				       : ErrorType.None;
		}

		private static ErrorType ProcessArrayOfStringType(string value, Condition conditions)
		{
			var result = JsonSerializer.Deserialize<List<string>>(value);
			if (result == null)
			{
				return ErrorType.InvalidValue;
			}
			conditions.ArrayOfStringValues = result;
			conditions.ParameterDataType = DataType.ArrayOfStringType;
			if (conditions.ArrayOfStringValues.Count == 0)
			{
				return ErrorType.EmptyList;
			}

			return HasListDuplicates(conditions.ArrayOfStringValues)
				       ? ErrorType.DuplicatesInList
				       : ErrorType.None;
		}

		private static ErrorType ProcessNumericType(string value, Condition conditions)
		{
			var result = JsonSerializer.Deserialize<decimal>(value);
			conditions.NumericValue      = result;
			conditions.ParameterDataType = DataType.NumericType;
			return ErrorType.None;
		}

		private ErrorType ProcessDateType(string value, Condition conditions)
		{
			var serializerOptions = new JsonSerializerOptions {Converters = {new DateTimeOffsetJsonConvertor()}};
			var result            = JsonSerializer.Deserialize<DateTime?>(value, serializerOptions);
			if (result == null)
			{
				return ErrorType.InvalidValue;
			}

			conditions.DateTimeValue = result.Value;
			conditions.ParameterDataType = DataType.DateType;
			return ErrorType.None;
		}

		private static ErrorType ProcessStringType(string value, Condition conditions)
		{
			var result = JsonSerializer.Deserialize<string>(value);
			if (result == null)
			{
				return ErrorType.InvalidValue;
			}
		
			conditions.StringValue = result;
			conditions.ParameterDataType = DataType.StringType;
			return ErrorType.None;
		}

		private static Comparer ParseOperator(string @operator)
		{
			return @operator.ToUpperInvariant() switch
			       {
				       "EQ" => Comparer.Eq,
				       "NE" => Comparer.Ne,
				       "LT" => Comparer.Lt,
				       "LE" => Comparer.Le,
				       "GE" => Comparer.Ge,
				       "GT" => Comparer.Gt,
				       "IN" => Comparer.In,
				       "NOTIN" => Comparer.Notin,
				       "LIKE" => Comparer.Like,
				       "STARTSWITH" => Comparer.Startswith,
				       "ENDSWITH" => Comparer.Endswith,
				       _ => Comparer.Unknown
			       };
		}

		#endregion Private
	}
}