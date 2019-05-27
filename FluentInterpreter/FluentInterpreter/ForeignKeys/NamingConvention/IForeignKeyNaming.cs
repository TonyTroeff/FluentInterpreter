namespace FluentInterpreter.ForeignKeys.NamingConvention
{
	public interface IForeignKeyNaming
	{
		string GetConstraintName(string descendantTable, string principalTable, string[] properties);
	}
}