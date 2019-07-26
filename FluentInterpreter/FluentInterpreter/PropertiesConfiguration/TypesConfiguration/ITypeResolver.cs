namespace FluentInterpreter.PropertiesConfiguration.TypesConfiguration
{
    public interface ITypeResolver
    {
        TypeCollection DefinedTypes { get; }

        string GetStringType(int length = 0, bool isUnicode = true, bool isFixedLength = false);

        string GetFloatingPointType(int precision = 18, int scale = 0);

        string GetMoneyType();
    }
}