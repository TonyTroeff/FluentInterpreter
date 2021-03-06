#region

using System;

#endregion

namespace FluentInterpreter.PropertiesConfiguration.TypesConfiguration
{
	public class PostgreSqlTypeResolver : ITypeResolver
	{
		public TypeCollection DefinedTypes { get; } = new TypeCollection
		{
			{typeof(byte), "smallint"},
			{typeof(short), "smallint"},
			{typeof(int), "integer"},
			{typeof(long), "bigint"},
			{typeof(bool), "boolean"},
			{typeof(Guid), "uuid"},
			{typeof(DateTime), "timestamp"},
			{typeof(DateTimeOffset), "timestamp with time zone"}
		};

		public string GetStringType(int length = 0, bool isUnicode = true, bool isFixedLength = false)
		{
			string type = "";

			if (isFixedLength == false) type += "var";

			type += $"char{(length > 0 ? $"({length.ToString()})" : "")}";

			return type;
		}

		public string GetFloatingPointType(int precision = 18, int scale = 0)
		{
			return $"decimal({precision}, {scale})";
		}

		public string GetMoneyType() { return "money"; }
	}
}