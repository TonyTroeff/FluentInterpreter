namespace FluentInterpreter.Indexes.NamingConvention
{
	public interface IIndexNaming
	{
		string GetConstraintName(string tableName, string[] properties);
	}
}