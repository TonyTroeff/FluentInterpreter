namespace FluentInterpreter.Indexes
{
	using System;
	using System.Linq.Expressions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public static class IndexConfiguration
	{
		public static void Index<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> properties,
			string sqlFilter = null)
			where T : class
		{
			string[] propertyNames = Common.GetPropertyNames(properties);

			string tableName = NamingServices.TableNaming.GetTableName(typeof(T));
			string indexName = NamingServices.IndexNaming.GetConstraintName(tableName, propertyNames);

			builder.HasIndex(properties)
				.HasName(indexName)
				.HasFilter(sqlFilter);
		}
	}
}