namespace FluentInterpreter.PropertiesConfiguration.TypesConfiguration
{
	using System;

	// ReSharper disable once InconsistentNaming
	public class SQLiteTypeResolver : ITypeResolver
	{
		public TypeCollection DefinedTypes { get; } = new TypeCollection
		{
			{ typeof(byte), "integer" },
			{ typeof(sbyte), "integer" },
			{ typeof(short), "integer" },
			{ typeof(ushort), "integer" },
			{ typeof(int), "integer" },
			{ typeof(uint), "integer" },
			{ typeof(long), "integer" },
			{ typeof(bool), "integer" },
			{ typeof(Guid), "blob" },
			{ typeof(DateTime), "text" }
		};

		public string GetStringType(int length = 0, bool isUnicode = true, bool isFixedLength = false) => "text";

		public string GetFloatingPointType(int precision = 18, int scale = 0) => "real";

		public string GetMoneyType() => "real";
	}
}