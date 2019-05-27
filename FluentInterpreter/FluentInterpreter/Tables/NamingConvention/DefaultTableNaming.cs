namespace FluentInterpreter.Tables.NamingConvention
{
	using System;
	using System.Text.RegularExpressions;
	using Humanizer;

	public class DefaultTableNaming : ITableNaming
	{
		public string GetTableName(Type type)
			=> Regex.Replace(type.Name, @"[A-Z][a-z]+", match => match.Value.Pluralize(false));
	}
}