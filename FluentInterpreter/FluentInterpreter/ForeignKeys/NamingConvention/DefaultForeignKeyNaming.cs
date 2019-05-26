namespace FluentInterpreter.ForeignKeys.NamingConvention
{
	public class DefaultForeignKeyNaming : IForeignKeyNaming
	{
		public string GetConstraintName(
			string descendantTableName,
			string principalTableName,
			string foreignKeyPropertyName)
			=> $"{Convention.FOREIGN_KEY_PREFIX}{Convention.DELIMITER}{descendantTableName}{Convention.DELIMITER}{principalTableName}{Convention.DELIMITER}{foreignKeyPropertyName}";
	}
}