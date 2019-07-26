namespace FluentInterpreter.DatabaseConfiguration
{
	using System;
	using System.Linq.Expressions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using NamingConvention;

	public static class UniqueIndexConfiguration
	{
		public static IndexBuilder Unique<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> propertiesExpression)
			where T : class
			=> builder.Unique(propertiesExpression, null);

		public static IndexBuilder Unique<T>(this EntityTypeBuilder<T> builder, params string[] properties)
			where T : class
			=> builder.Unique(properties, null);

		public static IndexBuilder Unique<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> propertiesExpression,
			string sqlFilter)
			where T : class
		{
			string[] properties = Common.GetMembers(propertiesExpression);

			return builder.Unique(properties, sqlFilter);
		}

		public static IndexBuilder Unique<T>(this EntityTypeBuilder<T> builder, string[] properties, string sqlFilter)
			where T : class
		{
			Common.CheckForNull(builder);
			Common.CheckStrings(properties);

			string taleName = NamingServices.TableNaming.GetTableName(typeof(T));
			string uniqueIndexName = NamingServices.UniqueIndexNaming.GetConstraintName(taleName, properties);

			return builder.Index(properties, sqlFilter)
				.IsUnique(true)
				.HasName(uniqueIndexName);
		}
	}
}