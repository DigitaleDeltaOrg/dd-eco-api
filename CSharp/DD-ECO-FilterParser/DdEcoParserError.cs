namespace DD_ECO_FilterParser
{
	/// <summary>
	///   An error definition consists of an error and its context (statement)
	/// </summary>
	public sealed class DdEcoParserError
	{
		public DdEcoParserError(ErrorType errorType, string context)
		{
			ErrorType = errorType;
			ErrorText = errorType.ToString();
			Context = context;
		}

		public ErrorType ErrorType { get; }

		public string ErrorText { get; }

		public string Context { get; }
	}
}