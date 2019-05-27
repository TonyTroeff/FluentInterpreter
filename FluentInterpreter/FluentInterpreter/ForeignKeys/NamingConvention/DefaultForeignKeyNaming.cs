namespace FluentInterpreter.ForeignKeys.NamingConvention
{
	using Exceptions;

	public class DefaultForeignKeyNaming : IForeignKeyNaming
	{
		public string GetConstraintName(string descendantTable, string principalTable, string[] properties)
		{
			if (string.IsNullOrEmpty(descendantTable)) throw new InvalidArgumentException(nameof(descendantTable));
			if (string.IsNullOrEmpty(principalTable)) throw new InvalidArgumentException(nameof(principalTable));
			if (properties == null
				|| properties.Length == 0) throw new InvalidArgumentException(nameof(properties));

			return
				$"{Convention.FOREIGN_KEY_PREFIX}{Convention.DELIMITER}{descendantTable}{Convention.DELIMITER}{principalTable}{Convention.DELIMITER}{string.Join(Convention.DELIMITER, properties)}";
		}
	}
}