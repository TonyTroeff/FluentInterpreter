namespace FluentInterpreter.ForeignKeys.NamingConvention
{
	public class DefaultForeignKeyNaming : IForeignKeyNaming
	{
		public string GetConstraintName(
			string descendantTableName,
			string principalTableName,
			params string[] foreignKeyPropertyNames)
			=> $"{Convention.FOREIGN_KEY_PREFIX}{Convention.DELIMITER}{descendantTableName}{Convention.DELIMITER}{principalTableName}{Convention.DELIMITER}{string.Join(Convention.DELIMITER, foreignKeyPropertyNames)}";
	}
}