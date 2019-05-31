namespace FluentInterpreter.NamingConvention.Default
{
	public class DefaultPrimaryKeyNaming : IPrimaryKeyNaming
	{
		public string GetConstraintName(string tableName, string[] properties)
		{
			Common.CheckStrings(tableName);
			Common.CheckStrings(properties);

			return
				$"{Convention.PRIMARY_KEY_PREFIX}{Convention.DELIMITER}{tableName}{Convention.DELIMITER}{string.Join(Convention.DELIMITER, properties)}";
		}
	}
}