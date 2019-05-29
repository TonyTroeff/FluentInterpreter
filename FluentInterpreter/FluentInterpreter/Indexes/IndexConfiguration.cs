namespace FluentInterpreter.Indexes
{
	using System;
	using System.Linq.Expressions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using NamingConvention;
	using Tables.NamingConvention;

	public static class IndexConfiguration
	{
		public static void Index<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> properties,
			ITableNaming tableNaming,
			IIndexNaming indexNaming)
			where T : class
			=> builder.Index(properties, null, tableNaming, indexNaming);

		public static void Index<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> properties,
			string sqlFilter,
			ITableNaming tableNaming,
			IIndexNaming indexNaming)
			where T : class
		{
			string[] propertyNames = Common.GetPropertyNames(properties);

			string tableName = tableNaming.GetTableName(typeof(T));
			string indexName = indexNaming.GetConstraintName(tableName, propertyNames);

			builder.HasIndex(properties)
				.HasName(indexName)
				.HasFilter(sqlFilter);
		}
	}
}