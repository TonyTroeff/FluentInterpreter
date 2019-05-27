namespace FluentInterpreter.ForeignKeys
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using NamingConvention;
	using Tables.NamingConvention;

	public static class ManyToOneConfiguration
	{
		public static void ManyToOne<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principalNavigationPropertyExpression,
			Expression<Func<TPrincipal, TDescendant>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, object>> foreignKeyPropertyExpression)
			where TDescendant : class
			where TPrincipal : class
			=> builder.ManyToOne(
				principalNavigationPropertyExpression,
				descendantNavigationPropertyExpression,
				foreignKeyPropertyExpression,
				new DefaultTableNaming(),
				new DefaultForeignKeyNaming());

		public static void ManyToOne<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principalNavigationPropertyExpression,
			Expression<Func<TPrincipal, TDescendant>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, object>> foreignKeyPropertyExpression,
			ITableNaming tableNaming)
			where TDescendant : class
			where TPrincipal : class
			=> builder.ManyToOne(
				principalNavigationPropertyExpression,
				descendantNavigationPropertyExpression,
				foreignKeyPropertyExpression,
				tableNaming,
				new DefaultForeignKeyNaming());

		public static void ManyToOne<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principalNavigationPropertyExpression,
			Expression<Func<TPrincipal, TDescendant>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, object>> foreignKeyPropertyExpression,
			IForeignKeyNaming foreignKeyNaming)
			where TDescendant : class
			where TPrincipal : class
			=> builder.ManyToOne(
				principalNavigationPropertyExpression,
				descendantNavigationPropertyExpression,
				foreignKeyPropertyExpression,
				new DefaultTableNaming(),
				foreignKeyNaming);

		public static void ManyToOne<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principalNavigationPropertyExpression,
			Expression<Func<TPrincipal, TDescendant>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, object>> foreignKeyPropertyExpression,
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

			builder.HasMany(principalNavigationPropertyExpression)
				.WithOne(descendantNavigationPropertyExpression)
				.HasForeignKey(foreignKeyPropertyExpression)
				.HasConstraintName(
					foreignKeyNaming.GetConstraintName(
						descendantTableName,
						principalTableName,
						foreignKeyPropertyName));
		}
	}
}