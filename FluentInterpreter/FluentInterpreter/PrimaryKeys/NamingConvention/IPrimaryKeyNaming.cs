namespace FluentInterpreter.PrimaryKeys.NamingConvention
{
	public interface IPrimaryKeyNaming
	{
		// TODO: Add primary key properties.
		string GetConstraintName(string tableName);
	}
}