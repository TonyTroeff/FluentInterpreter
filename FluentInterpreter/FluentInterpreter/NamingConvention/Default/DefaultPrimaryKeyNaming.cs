namespace FluentInterpreter.NamingConvention.Default
{
	public class DefaultPrimaryKeyNaming : IPrimaryKeyNaming
	{
		public string GetConstraintName(string tableName, string[] columns)
		{
			Common.CheckStrings(tableName);
			Common.CheckStrings(columns);

			return
				$"{Convention.PRIMARY_KEY_PREFIX}{Convention.DELIMITER}{tableName}{Convention.DELIMITER}{string.Join(Convention.DELIMITER, columns)}";
		}
	}
}