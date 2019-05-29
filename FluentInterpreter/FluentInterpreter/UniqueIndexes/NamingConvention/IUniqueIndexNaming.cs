namespace FluentInterpreter.UniqueIndexes.NamingConvention
{
	public interface IUniqueIndexNaming
	{
		string GetConstraintName(string tableName, string[] properties);
	}
}