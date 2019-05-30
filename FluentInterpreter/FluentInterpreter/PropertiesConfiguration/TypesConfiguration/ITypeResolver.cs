namespace FluentInterpreter.PropertiesConfiguration.TypesConfiguration
{
	using System.Globalization;

	public interface ITypeResolver
	{
		TypeCollection DefinedTypes { get; }

		string GetStringType(int length = 0, bool isUnicode = true, bool isFixedLength = false);

		string GetFloatingPointType(int precision, int scale = 0);

		string GetMoneyType();
	}
}