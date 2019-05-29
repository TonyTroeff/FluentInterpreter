namespace FluentInterpreter.UniqueIndexes.NamingConvention
{
	using Exceptions;

	public class DefaultUniqueIndexNaming : IUniqueIndexNaming
	{
		public string GetConstraintName(string tableName, string[] properties)
		{
			if (string.IsNullOrEmpty(tableName)) throw new InvalidArgumentException(nameof(tableName));
			if (properties == null
				|| properties.Length == 0) throw new InvalidArgumentException(nameof(properties));

			return
				$"{Convention.UNIQUE_INDEX_PREFIX}{Convention.DELIMITER}{tableName}{Convention.DELIMITER}{string.Join(Convention.DELIMITER, properties)}";
		}
	}
}