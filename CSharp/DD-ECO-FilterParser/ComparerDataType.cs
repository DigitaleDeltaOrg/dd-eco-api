namespace DD_ECO_FilterParser
{
	/// <summary>
	///   Defines an operation/data type combination.
	/// </summary>
	public class ComparerDataType
	{
		public ComparerDataType(Comparer comparer, DataType dataType)
		{
			Comparer = comparer;
			DataType = dataType;
		}

		public Comparer Comparer { set; get; }
		public DataType DataType { set; get; }
	}
}