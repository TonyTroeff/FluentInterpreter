namespace FluentInterpreter.PropertiesConfiguration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using NamingConvention;

	public static class PropertyConfiguration
	{
		public static PropertyBuilder<T> Name<T>(this PropertyBuilder<T> builder)
		{
			Common.CheckForNull(builder);
			
			return builder.Name(NamingServices.ColumnNaming.GetColumnName(builder.Metadata.Name));
		}

		public static PropertyBuilder<T> Name<T>(this PropertyBuilder<T> builder, string name)
		{
			Common.CheckForNull(builder);
			Common.CheckStrings(name);
			
			return builder.HasColumnName(name);
		}

		public static PropertyBuilder<T> ResolveType<T>(this PropertyBuilder<T> builder)
		{
			Common.CheckForNull(builder);
			
			string type = Provider.GetTypeResolver()
				.DefinedTypes.GetType(typeof(T));
			return builder.CustomType(type);
		}

		public static PropertyBuilder<T> MoneyType<T>(this PropertyBuilder<T> builder)
		{
			Common.CheckForNull(builder);
			
			string type = Provider.GetTypeResolver()
				.GetMoneyType();
			return builder.CustomType(type);
		}

		public static PropertyBuilder<T> StringType<T>(
			this PropertyBuilder<T> builder,
			int length = 0,
			bool isUnicode = true,
			bool isFixedLength = false)
		{
			Common.CheckForNull(builder);
			
			string type = Provider.GetTypeResolver()
				.GetStringType(length, isUnicode, isFixedLength);
			return builder.CustomType(type);
		}

		public static PropertyBuilder<T> FloatingPointType<T>(
			this PropertyBuilder<T> builder,
			int precision = 18,
			int scale = 0)
		{
			Common.CheckForNull(builder);
			
			string type = Provider.GetTypeResolver()
				.GetFloatingPointType(precision, scale);
			return builder.CustomType(type);
		}

		public static PropertyBuilder<T> CustomType<T>(this PropertyBuilder<T> builder, string type)
		{
			Common.CheckForNull(builder);
			Common.CheckStrings(type);
			
			return builder.HasColumnType(type);
		}

		public static PropertyBuilder<T> Default<T>(this PropertyBuilder<T> builder, T defaultValue)
		{
			Common.CheckForNull(builder);
			Common.CheckForNull(defaultValue);
			
			return builder.HasDefaultValue(defaultValue);
		}
	}
}