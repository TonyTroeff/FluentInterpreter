namespace FluentInterpreter.PrimaryKeys.NamingConvention
{
	using System;
	using Exceptions;

	public class DefaultPrimaryKeyNaming : IPrimaryKeyNaming
	{
		public string GetConstraintName(string tableName, params string[] properties)
		{
			if (string.IsNullOrEmpty(tableName)) throw new InvalidArgumentException(nameof(tableName));
			if (properties == null || properties.Length == 0) throw new InvalidArgumentException(nameof(properties));
				
			return $"{Convention.PRIMARY_KEY_PREFIX}{Convention.DELIMITER}{tableName}{Convention.DELIMITER}";
		}
	}
}