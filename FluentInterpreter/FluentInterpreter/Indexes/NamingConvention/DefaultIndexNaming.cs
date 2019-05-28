namespace FluentInterpreter.Indexes.NamingConvention
{
	using Exceptions;

	public class DefaultIndexNaming : IIndexNaming
	{
		public string GetConstraintName(string tableName, string[] properties)
		{
			if (string.IsNullOrEmpty(tableName)) throw new InvalidArgumentException(nameof(tableName));
			if (properties == null
				|| properties.Length == 0) throw new InvalidArgumentException(nameof(properties));

			return
				$"{Convention.INDEX_PREFIX}{Convention.DELIMITER}{tableName}{Convention.DELIMITER}{string.Join(Convention.DELIMITER, properties)}";
		}
	}
}