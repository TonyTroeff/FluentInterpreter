namespace FluentInterpreter.Tables.NamingConvention
{
	using System;
	using System.Text.RegularExpressions;
	using Exceptions;
	using Humanizer;

	public class DefaultTableNaming : ITableNaming
	{
		public string GetTableName(Type type)
		{
			if (type == null) throw new InvalidArgumentException(nameof(type));

			return Regex.Replace(type.Name, @"[A-Z][a-z]+", match => match.Value.Pluralize(false));
		}
	}
}