namespace FluentInterpreter.PrimaryKeys
{
	using System;
	using System.Linq.Expressions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public static class PrimaryKeyConfiguration
	{
		public static void PrimaryKey<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> primaryKeyExpression)
			where T : class
		{
			string[] properties = Common.GetPropertyNames(primaryKeyExpression);

			string tableName = NamingServices.TableNaming.GetTableName(typeof(T));
			string primaryKeyName = NamingServices.PrimaryKeyNaming.GetConstraintName(tableName, properties);

			builder.HasKey(primaryKeyExpression)
				.HasName(primaryKeyName);

			// TODO: Add indexes.
			// Indexes should be added for every property that is not part of the clustered index.
			// Custom index implementation overrides the one made by convention (EF Core).
		}
	}
}