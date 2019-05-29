namespace FluentInterpreter.PrimaryKeys
{
	using System;
	using System.Linq.Expressions;
	using Indexes;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public static class PrimaryKeyConfiguration
	{
		public static void PrimaryKey<T>(
			this EntityTypeBuilder<T> builder,
			Expression<Func<T, object>> primaryKeyExpression)
			where T : class
		{
			string[] properties = Common.GetMembers(primaryKeyExpression);
			builder.PrimaryKey(properties);
		}
		
		public static void PrimaryKey<T>(
			this EntityTypeBuilder<T> builder,
			params string[] properties)
			where T : class
		{
			string tableName = NamingServices.TableNaming.GetTableName(typeof(T));
			string primaryKeyName = NamingServices.PrimaryKeyNaming.GetConstraintName(tableName, properties);

			builder.HasKey(properties)
				.HasName(primaryKeyName);

			for (int i = 1; i < properties.Length; i++) builder.Index(properties[i]);
		}
	}
}