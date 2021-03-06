#region

using System;

#endregion

namespace FluentInterpreter.PropertiesConfiguration.TypesConfiguration
{
    public class SqlServerTypeResolver : ITypeResolver
    {
        public TypeCollection DefinedTypes { get; } = new TypeCollection
        {
            {typeof(byte), "tinyint"},
            {typeof(short), "smallint"},
            {typeof(int), "int"},
            {typeof(long), "bigint"},
            {typeof(bool), "bit"},
            {typeof(Guid), "uniqueidentifier"},
            {typeof(DateTime), "datetime2"},
            {typeof(DateTimeOffset), "datetimeoffset"},
        };

        public string GetStringType(int length = 0, bool isUnicode = true, bool isFixedLength = false)
        {
            string type = "";

            if (isUnicode) type += "n";
            if (isFixedLength == false) type += "var";

            type += $"char({(length <= 0 ? "max" : length.ToString())})";

            return type;
        }

        public string GetFloatingPointType(int precision = 18, int scale = 0)
        {
            return $"decimal({precision}, {scale})";
        }

        public string GetMoneyType()
        {
            return "money";
        }
    }
}