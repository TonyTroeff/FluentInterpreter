namespace FluentInterpreter.PropertiesConfiguration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using NamingConvention;

	public static class PropertyConfiguration
	{
		// public static PropertyBuilder<T> Configure<T>(
		// 	this PropertyBuilder<T> builder,
		// 	string name,
		// 	string type,
		// 	bool isRequired)
		// 	=> builder.HasColumnName(name)
		// 		.HasColumnType(type)
		// 		.IsRequired(isRequired);

		public static PropertyBuilder<T> Name<T>(this PropertyBuilder<T> builder)
			=> builder.Name(NamingServices.PropertyNaming.GetPropertyName(builder.Metadata.Name));

		public static PropertyBuilder<T> Name<T>(this PropertyBuilder<T> builder, string name)
		{
			Common.CheckParameters(name.ToCharArray());
			return builder.HasColumnName(name);
		}

		// TODO: Check provider;
		public static PropertyBuilder<T> DefinedType<T>(this PropertyBuilder<T> builder)
		{
			string type = Provider.TypeResolver.DefinedTypes.GetTypeName(typeof(T));
			return builder.Type(type);
		}

		public static PropertyBuilder<T> MoneyType<T>(this PropertyBuilder<T> builder)
		{
			string type = Provider.TypeResolver.GetMoneyType();
			return builder.Type(type);
		}

		public static PropertyBuilder<T> StringType<T>(
			this PropertyBuilder<T> builder,
			int length = 0,
			bool isUnicode = true,
			bool isFixedLength = false)
		{
			string type = Provider.TypeResolver.GetStringType(length, isUnicode, isFixedLength);
			return builder.Type(type);
		}

		public static PropertyBuilder<T> FloatingPointType<T>(
			this PropertyBuilder<T> builder,
			int precision,
			int scale = 0)
		{
			string type = Provider.TypeResolver.GetFloatingPointType(precision, scale);
			return builder.Type(type);
		}

		public static PropertyBuilder<T> Type<T>(this PropertyBuilder<T> builder, string type)
		{
			Common.CheckParameters(type.ToCharArray());
			return builder.HasColumnType(type);
		}
	}
}