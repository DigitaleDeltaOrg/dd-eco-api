namespace DD_ECO_FilterParser
{
	/// <summary>
	///   Possible error types.
	/// </summary>
	public enum ErrorType
	{
		None = 0,
		UnknownField = 1,
		UnknownOperator = 2,
		InvalidValue = 3,
		InvalidSyntax = 4,
		InvalidOperatorForField = 5,
		DuplicatesInList = 6,
		EmptyList = 7,
		InvalidDataType = 8,
		Separator = 9,
		DateFormatter = 10,
		DateFormatterDateFormat = 11,
		Required = 12
	}
}