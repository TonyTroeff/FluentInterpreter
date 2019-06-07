namespace FluentInterpreter.DatabaseConfiguration
{
	using System;
	using System.Linq.Expressions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using NamingConvention;

	public static class IndexConfiguration
	{
		public static IndexBuilder Index<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> propertiesExpression)
			where T : class
			=> builder.Index(propertiesExpression, null);

		public static IndexBuilder Index<T>(this EntityTypeBuilder<T> builder, params string[] properties)
			where T : class
			=> builder.Index(properties, null);

		public static IndexBuilder Index<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> propertiesExpression,
			string sqlFilter)
			where T : class
		{
			string[] properties = Common.GetMembers(propertiesExpression);

			return builder.Index(properties, sqlFilter);
		}

		public static IndexBuilder Index<T>(this EntityTypeBuilder<T> builder, string[] properties, string sqlFilter)
			where T : class
		{
			Common.CheckForNull(builder);
			Common.CheckStrings(properties);

			string tableName = NamingServices.TableNaming.GetTableName(typeof(T));
			string indexName = NamingServices.IndexNaming.GetConstraintName(tableName, properties);

			return builder.HasIndex(properties)
				.HasName(indexName)
				.HasFilter(sqlFilter);
		}
	}
}