namespace FluentInterpreter.NamingConvention.Default
{
	using Humanizer;

	public class DefaultPropertyNaming : IPropertyNaming
	{
		public string GetPropertyName(string propertyName) => propertyName.Pascalize();
	}
}