using System.Collections.Generic;

namespace DD_ECO_FilterParser
{
	public class FieldDefinition
	{
		public FieldDefinition(string fieldName, string description, List<ComparerDataType> comparerDataTypes, bool required = false, string? mappedFieldName = null)
		{
			FieldName         = fieldName;
			ComparerDataTypes = comparerDataTypes;
			Required          = required;
			MappedFieldName   = mappedFieldName ?? fieldName;
			Description       = description;
		}

		public string                 FieldName         { get; }
		public List<ComparerDataType> ComparerDataTypes { get; }
		public bool                   Required          { get; }
		public string                 MappedFieldName   { get; }
		public string                 Description       { get; }
	}
}