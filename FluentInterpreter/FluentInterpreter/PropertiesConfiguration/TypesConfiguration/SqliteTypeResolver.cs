#region

using System;

#endregion

namespace FluentInterpreter.PropertiesConfiguration.TypesConfiguration
{
    // ReSharper disable once InconsistentNaming
    public class SqliteTypeResolver : ITypeResolver
    {
        public TypeCollection DefinedTypes { get; } = new TypeCollection
        {
            {typeof(byte), "integer"},
            {typeof(sbyte), "integer"},
            {typeof(short), "integer"},
            {typeof(ushort), "integer"},
            {typeof(int), "integer"},
            {typeof(uint), "integer"},
            {typeof(long), "integer"},
            {typeof(bool), "integer"},
            {typeof(Guid), "blob"},
            {typeof(DateTime), "text"},
            {typeof(DateTimeOffset), "text"}
        };

        public string GetStringType(int length = 0, bool isUnicode = true, bool isFixedLength = false)
        {
            return "text";
        }

        public string GetFloatingPointType(int precision = 18, int scale = 0)
        {
            return "real";
        }

        public string GetMoneyType()
        {
            return "real";
        }
    }
}