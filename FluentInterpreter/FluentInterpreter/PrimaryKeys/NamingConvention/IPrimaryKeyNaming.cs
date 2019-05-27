namespace FluentInterpreter.PrimaryKeys.NamingConvention
{
	public interface IPrimaryKeyNaming
	{
		string GetConstraintName(string tableName, params string[] properties);
	}
}