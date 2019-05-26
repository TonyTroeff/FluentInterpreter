namespace FluentInterpreter.Tables.NamingConvention
{
	using System;
	using System.Text.RegularExpressions;

	public class DefaultTableNaming : ITableNaming
	{
		public string GetTableName(Type type) => Regex.Replace(type.Name, @"[A-Z][a-z]+", match => $"{match.Value}s");
	}
}