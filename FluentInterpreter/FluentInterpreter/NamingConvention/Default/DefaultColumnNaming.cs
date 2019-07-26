namespace FluentInterpreter.NamingConvention.Default
{
	using Humanizer;

	public class DefaultColumnNaming : IColumnNaming
	{
		public string GetColumnName(string propertyName)
		{
			Common.CheckStrings(propertyName);

			return propertyName.Pascalize();
		}
	}
}