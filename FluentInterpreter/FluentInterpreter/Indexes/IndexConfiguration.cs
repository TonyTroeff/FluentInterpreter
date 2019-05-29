namespace FluentInterpreter.Indexes
{
	using System;
	using System.Linq.Expressions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public static class IndexConfiguration
	{
		public static void Index<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, object>> propertiesExpression)
			where T : class
		{
			string[] properties = Common.GetMembers(propertiesExpression);

			builder.Index(properties, null);
		}

		public static void Index<T>(this EntityTypeBuilder<T> builder, params string[] properties)
			where T : class
			=> builder.Index(properties, null);

		public static void Index<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> propertiesExpression,
			string sqlFilter)
			where T : class
		{
			string[] properties = Common.GetMembers(propertiesExpression);

			builder.Index(properties, sqlFilter);
		}

		public static void Index<T>(this EntityTypeBuilder<T> builder, string[] properties, string sqlFilter)
			where T : class
		{
			string tableName = NamingServices.TableNaming.GetTableName(typeof(T));
			string indexName = NamingServices.IndexNaming.GetConstraintName(tableName, properties);

			builder.HasIndex(properties)
				.HasName(indexName)
				.HasFilter(sqlFilter);
		}
	}
}