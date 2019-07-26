namespace FluentInterpreter.NamingConvention.Default
{
	public class DefaultIndexNaming : IIndexNaming
	{
		public string GetConstraintName(string tableName, string[] properties)
		{
			Common.CheckStrings(tableName);
			Common.CheckStrings(properties);

			return
				$"{Convention.INDEX_PREFIX}{Convention.DELIMITER}{tableName}{Convention.DELIMITER}{string.Join(Convention.DELIMITER, properties)}";
		}
	}
}