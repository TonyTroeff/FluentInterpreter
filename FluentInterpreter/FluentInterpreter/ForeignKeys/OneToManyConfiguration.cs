namespace FluentInterpreter.ForeignKeys
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using NamingConvention;
	using Tables.NamingConvention;

	public static class OneToManyConfiguration
	{
		public static void OneToMany<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, TPrincipal>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, IEnumerable<TDescendant>>> principalNavigationPropertyExpression,
			Expression<Func<TDescendant, object>> foreignKeyPropertyExpression)
			where TDescendant : class
			where TPrincipal : class
			=> builder.OneToMany(
				descendantNavigationPropertyExpression,
				principalNavigationPropertyExpression,
				foreignKeyPropertyExpression,
				new DefaultTableNaming(),
				new DefaultForeignKeyNaming());

		public static void OneToMany<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, TPrincipal>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, IEnumerable<TDescendant>>> principalNavigationPropertyExpression,
			Expression<Func<TDescendant, object>> foreignKeyPropertyExpression,
			ITableNaming tableNaming)
			where TDescendant : class
			where TPrincipal : class
			=> builder.OneToMany(
				descendantNavigationPropertyExpression,
				principalNavigationPropertyExpression,
				foreignKeyPropertyExpression,
				tableNaming,
				new DefaultForeignKeyNaming());

		public static void OneToMany<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, TPrincipal>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, IEnumerable<TDescendant>>> principalNavigationPropertyExpression,
			Expression<Func<TDescendant, object>> foreignKeyPropertyExpression,
			IForeignKeyNaming foreignKeyNaming)
			where TDescendant : class
			where TPrincipal : class
			=> builder.OneToMany(
				descendantNavigationPropertyExpression,
				principalNavigationPropertyExpression,
				foreignKeyPropertyExpression,
				new DefaultTableNaming(),
				foreignKeyNaming);

		public static void OneToMany<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, TPrincipal>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, IEnumerable<TDescendant>>> principalNavigationPropertyExpression,
			Expression<Func<TDescendant, object>> foreignKeyPropertyExpression,
			ITableNaming tableNaming,
			IForeignKeyNaming foreignKeyNaming)
			where TDescendant : class
			where TPrincipal : class
		{
			// TODO: Create custom exceptions.
			if (descendantNavigationPropertyExpression.Body is MemberExpression == false) throw new ArgumentException();
			if (principalNavigationPropertyExpression.Body is MemberExpression == false) throw new ArgumentException();

			string[] foreignKeyPropertyName = Common.GetPropertyNames(foreignKeyPropertyExpression);

			string descendantTableName = tableNaming.GetTableName(typeof(TDescendant));
			string principalTableName = tableNaming.GetTableName(typeof(TPrincipal));

			builder.HasOne(descendantNavigationPropertyExpression)
				.WithMany(principalNavigationPropertyExpression)
				.HasForeignKey(foreignKeyPropertyExpression)
				.HasConstraintName(
					foreignKeyNaming.GetConstraintName(
						descendantTableName,
						principalTableName,
						foreignKeyPropertyName));
		}
	}
}