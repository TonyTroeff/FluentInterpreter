namespace FluentInterpreter.PropertiesConfiguration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public static class PropertyConfiguration
	{
		public static PropertyBuilder<T> Configure<T>(
			this PropertyBuilder<T> builder,
			string name,
			string type,
			bool isRequired)
			=> builder.HasColumnName(name)
				.HasColumnType(type)
				.IsRequired(isRequired);
	}
}