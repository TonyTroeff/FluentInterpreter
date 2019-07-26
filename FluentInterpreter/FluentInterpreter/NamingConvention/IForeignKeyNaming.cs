namespace FluentInterpreter.NamingConvention
{
	public interface IForeignKeyNaming
	{
		string GetConstraintName(string dependentTable, string principalTable, string[] columns);
	}
}