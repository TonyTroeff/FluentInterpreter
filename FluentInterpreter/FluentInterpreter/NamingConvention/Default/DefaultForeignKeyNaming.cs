namespace FluentInterpreter.NamingConvention.Default
{
	using Exceptions;
	using NamingConvention;

	public class DefaultForeignKeyNaming : IForeignKeyNaming
	{
		public string GetConstraintName(string dependentTable, string principalTable, string[] properties)
		{
			if (string.IsNullOrEmpty(dependentTable)) throw new InvalidArgumentException(nameof(dependentTable));
			if (string.IsNullOrEmpty(principalTable)) throw new InvalidArgumentException(nameof(principalTable));
			if (properties == null
				|| properties.Length == 0) throw new InvalidArgumentException(nameof(properties));

			return
				$"{Convention.FOREIGN_KEY_PREFIX}{Convention.DELIMITER}{dependentTable}{Convention.DELIMITER}{principalTable}{Convention.DELIMITER}{string.Join(Convention.DELIMITER, properties)}";
		}
	}
}