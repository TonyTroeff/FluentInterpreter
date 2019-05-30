namespace FluentInterpreter.NamingConvention
{
	public interface IUniqueIndexNaming
	{
		string GetConstraintName(string tableName, string[] properties);
	}
}