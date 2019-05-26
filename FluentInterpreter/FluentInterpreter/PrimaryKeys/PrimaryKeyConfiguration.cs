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
		// TODO: Add index.
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
			=> builder.HasKey(primaryKeyExpression)
				.HasName(primaryKeyNaming.GetConstraintName(tableNaming.GetTableName(typeof(T))));
	}
}