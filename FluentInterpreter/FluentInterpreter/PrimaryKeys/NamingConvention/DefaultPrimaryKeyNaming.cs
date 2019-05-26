namespace FluentInterpreter.PrimaryKeys.NamingConvention
{
	public class DefaultPrimaryKeyNaming : IPrimaryKeyNaming
	{
		public string GetConstraintName(string tableName)
			=> $"{Convention.PRIMARY_KEY_PREFIX}{Convention.DELIMITER}{tableName}";
	}
}