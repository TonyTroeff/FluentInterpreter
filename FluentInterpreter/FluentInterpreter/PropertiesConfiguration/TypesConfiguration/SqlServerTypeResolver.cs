namespace FluentInterpreter.PropertiesConfiguration.TypesConfiguration
{
	using System;

	public class SqlServerTypeResolver : ITypeResolver
	{
		public TypeCollection DefinedTypes { get; } = new TypeCollection()
		{
			{ typeof(byte), "tinyint" },
			{ typeof(short), "smallint" },
			{ typeof(int), "int" },
			{ typeof(long), "bigint" },
			{ typeof(bool), "bit" },
			{ typeof(Guid), "uniqueidentifier" },
			{ typeof(DateTime), "datetime2" }
		};

		public string GetStringType(int length = 0, bool isUnicode = true, bool isFixedLength = false)
		{
			string type = "";

			if (isUnicode) type += "n";
			if (isFixedLength == false) type += "var";

			type += $"char({(length <= 0 ? "max" : length.ToString())})";

			return type;
		}

		public string GetFloatingPointType(int precision, int scale = 0) => $"decimal({precision}, {scale})";

		public string GetMoneyType() => "money";
	}
}