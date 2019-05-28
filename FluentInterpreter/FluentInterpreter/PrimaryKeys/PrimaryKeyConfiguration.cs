namespace FluentInterpreter.PrimaryKeys
{
	using System;
	using System.Linq.Expressions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using NamingConvention;
	using Tables.NamingConvention;

	public static class PrimaryKeyConfiguration
	{
		public static void PrimaryKey<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> primaryKeyExpression)
			where T : class
			=> builder.PrimaryKey(primaryKeyExpression, new DefaultTableNaming(), new DefaultPrimaryKeyNaming());

		public static void PrimaryKey<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> primaryKeyExpression,
			ITableNaming tableNaming)
			where T : class
			=> builder.PrimaryKey(primaryKeyExpression, tableNaming, new DefaultPrimaryKeyNaming());

		public static void PrimaryKey<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> primaryKeyExpression,
			IPrimaryKeyNaming primaryKeyNaming)
			where T : class
			=> builder.PrimaryKey(primaryKeyExpression, new DefaultTableNaming(), primaryKeyNaming);

		public static void PrimaryKey<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> primaryKeyExpression,
			ITableNaming tableNaming,
			IPrimaryKeyNaming primaryKeyNaming)
			where T : class
		{
			string[] properties = Common.GetPropertyNames(primaryKeyExpression);

			builder.HasKey(primaryKeyExpression)
				.HasName(primaryKeyNaming.GetConstraintName(tableNaming.GetTableName(typeof(T)), properties));
			
			// TODO: Add indexes.
			// Indexes should be added for every property that is not part of the clustered index.
			// Custom index implementation overrides the one made by convention (EF Core).
		}
	}
}