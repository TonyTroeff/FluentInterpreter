namespace FluentInterpreter.NamingConvention
{
	using System;

	public interface ITableNaming
	{
		string GetTableName(Type type);
	}
}