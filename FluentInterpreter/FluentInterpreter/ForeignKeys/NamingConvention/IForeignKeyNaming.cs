namespace FluentInterpreter.ForeignKeys.NamingConvention
{
	public interface IForeignKeyNaming
	{
		string GetConstraintName(string descendantTableName, string principalTableName, string foreignKeyPropertyName);
	}
}