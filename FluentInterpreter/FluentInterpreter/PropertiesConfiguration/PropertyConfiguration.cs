namespace FluentInterpreter.PropertiesConfiguration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using NamingConvention;

	public static class PropertyConfiguration
	{
		public static PropertyBuilder<T> Name<T>(this PropertyBuilder<T> builder)
			=> builder.Name(NamingServices.PropertyNaming.GetPropertyName(builder.Metadata.Name));

		public static PropertyBuilder<T> Name<T>(this PropertyBuilder<T> builder, string name)
		{
			Common.CheckStrings(name);
			return builder.HasColumnName(name);
		}

		public static PropertyBuilder<T> ResolveType<T>(this PropertyBuilder<T> builder)
		{
			string type = Provider.GetTypeResolver()
				.DefinedTypes.GetType(typeof(T));
			return builder.CustomType(type);
		}

		public static PropertyBuilder<T> MoneyType<T>(this PropertyBuilder<T> builder)
		{
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
			string type = Provider.GetTypeResolver()
				.GetStringType(length, isUnicode, isFixedLength);
			return builder.CustomType(type);
		}

		public static PropertyBuilder<T> FloatingPointType<T>(
			this PropertyBuilder<T> builder,
			int precision,
			int scale = 0)
		{
			string type = Provider.GetTypeResolver()
				.GetFloatingPointType(precision, scale);
			return builder.CustomType(type);
		}

		public static PropertyBuilder<T> CustomType<T>(this PropertyBuilder<T> builder, string type)
		{
			Common.CheckStrings(type);
			return builder.HasColumnType(type);
		}

		public static PropertyBuilder<T> Default<T>(this PropertyBuilder<T> builder, T defaultValue)
		{
			Common.CheckForNull(defaultValue);
			return builder.HasDefaultValue(defaultValue);
		}
	}
}