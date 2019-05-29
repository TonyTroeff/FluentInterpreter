namespace FluentInterpreter.ForeignKeys.NamingConvention
{
	public interface IForeignKeyNaming
	{
		string GetConstraintName(string dependentTable, string principalTable, string[] properties);
	}
}