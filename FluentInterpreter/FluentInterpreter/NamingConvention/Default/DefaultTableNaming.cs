namespace FluentInterpreter.NamingConvention.Default
{
	using System;
	using System.Text.RegularExpressions;
	using Humanizer;

	public class DefaultTableNaming : ITableNaming
	{
		public string GetTableName(Type type)
		{
			Common.CheckForNull(type);

			return Regex.Replace(type.Name, @"[A-Z][a-z]+", match => match.Value.Pluralize(false));
		}
	}
}