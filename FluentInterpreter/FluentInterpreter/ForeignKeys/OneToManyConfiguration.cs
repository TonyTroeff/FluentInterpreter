namespace FluentInterpreter.ForeignKeys
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using Exceptions;
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
			Expression<Func<TDescendant, object>> foreignKeyExpression,
			ITableNaming tableNaming,
			IForeignKeyNaming foreignKeyNaming)
			where TDescendant : class
			where TPrincipal : class
		{
			if (descendantNavigationPropertyExpression.Body is MemberExpression == false)
				throw new NotMemberExpressionException(nameof(descendantNavigationPropertyExpression));
			if (principalNavigationPropertyExpression.Body is MemberExpression == false)
				throw new NotMemberExpressionException(nameof(principalNavigationPropertyExpression));

			string[] foreignKeyPropertyName = Common.GetPropertyNames(foreignKeyExpression);

			string descendantTableName = tableNaming.GetTableName(typeof(TDescendant));
			string principalTableName = tableNaming.GetTableName(typeof(TPrincipal));

			builder.HasOne(descendantNavigationPropertyExpression)
				.WithMany(principalNavigationPropertyExpression)
				.HasForeignKey(foreignKeyExpression)
				.HasConstraintName(
					foreignKeyNaming.GetConstraintName(
						descendantTableName,
						principalTableName,
						foreignKeyPropertyName));
		}
	}
}