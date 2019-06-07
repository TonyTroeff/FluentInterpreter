namespace FluentInterpreter.NamingConvention
{
	public interface IPrimaryKeyNaming
	{
		string GetConstraintName(string tableName, string[] columns);
	}
}