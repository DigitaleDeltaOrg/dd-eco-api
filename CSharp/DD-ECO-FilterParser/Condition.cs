using System;
using System.Collections.Generic;

namespace DD_ECO_FilterParser
{
	/// <summary>
	///   Defines a statement: a part of the filter that includes field name, operator and field value.
	/// </summary>
	public class Condition
	{
		/// <summary>
		///   Constructor
		/// </summary>
		public Condition()
		{
			Errors = new();
		}

		public string                 FieldName            { set; get; } = string.Empty;
		public Comparer               Comparers            { set; get; }
		public string                 StringValue          { set; get; } = string.Empty;
		public DateTime               DateTimeValue        { set; get; }
		public decimal                NumericValue         { set; get; }
		public List<string>           ArrayOfStringValues  { set; get; } = new();
		public List<decimal>          ArrayOfNumericValues { set; get; } = new();
		public DataType               ParameterDataType    { set; get; }
		public List<(string, string)> KeyValuePairs        { set; get; } = new();
		public List<DdEcoParserError> Errors               { set; get; }
	}
}