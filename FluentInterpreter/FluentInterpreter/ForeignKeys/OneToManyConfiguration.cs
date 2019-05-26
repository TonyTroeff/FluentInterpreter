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
		public static void OneToMany<TDescendant, TPrincipal, TForeignKey>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, TPrincipal>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, IEnumerable<TDescendant>>> principalNavigationPropertyExpression,
			Expression<Func<TDescendant, TForeignKey>> foreignKeyPropertyExpression)
			where TDescendant : class
			where TPrincipal : class
			=> builder.OneToMany(
				descendantNavigationPropertyExpression,
				principalNavigationPropertyExpression,
				foreignKeyPropertyExpression,
				new DefaultTableNaming(),
				new DefaultForeignKeyNaming());

		public static void OneToMany<TDescendant, TPrincipal, TForeignKey>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, TPrincipal>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, IEnumerable<TDescendant>>> principalNavigationPropertyExpression,
			Expression<Func<TDescendant, TForeignKey>> foreignKeyPropertyExpression,
			ITableNaming tableNaming)
			where TDescendant : class
			where TPrincipal : class
			=> builder.OneToMany(
				descendantNavigationPropertyExpression,
				principalNavigationPropertyExpression,
				foreignKeyPropertyExpression,
				tableNaming,
				new DefaultForeignKeyNaming());

		public static void OneToMany<TDescendant, TPrincipal, TForeignKey>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, TPrincipal>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, IEnumerable<TDescendant>>> principalNavigationPropertyExpression,
			Expression<Func<TDescendant, TForeignKey>> foreignKeyPropertyExpression,
			IForeignKeyNaming foreignKeyNaming)
			where TDescendant : class
			where TPrincipal : class
			=> builder.OneToMany(
				descendantNavigationPropertyExpression,
				principalNavigationPropertyExpression,
				foreignKeyPropertyExpression,
				new DefaultTableNaming(),
				foreignKeyNaming);

		public static void OneToMany<TDescendant, TPrincipal, TForeignKey>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, TPrincipal>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, IEnumerable<TDescendant>>> principalNavigationPropertyExpression,
			Expression<Func<TDescendant, TForeignKey>> foreignKeyPropertyExpression,
			ITableNaming tableNaming,
			IForeignKeyNaming foreignKeyNaming)
			where TDescendant : class
			where TPrincipal : class
		{
			// TODO: Create custom exceptions.
			if (!(foreignKeyPropertyExpression.Body is MemberExpression foreignKeyExpresion))
				throw new ArgumentException();
			if (descendantNavigationPropertyExpression.Body is MemberExpression == false) throw new ArgumentException();
			if (principalNavigationPropertyExpression.Body is MemberExpression == false) throw new ArgumentException();

			string descendantTableName = tableNaming.GetTableName(typeof(TDescendant));
			string principalTableName = tableNaming.GetTableName(typeof(TPrincipal));
			string foreignKeyPropertyName = foreignKeyExpresion.Member.Name;

			builder.HasOne(descendantNavigationPropertyExpression)
				.WithMany(principalNavigationPropertyExpression)
				.HasForeignKey(
					Expression.Lambda<Func<TDescendant, object>>(
						Expression.Convert(foreignKeyPropertyExpression.Body, typeof(object)),
						foreignKeyPropertyExpression.Parameters))
				.HasConstraintName(
					foreignKeyNaming.GetConstraintName(
						descendantTableName,
						principalTableName,
						foreignKeyPropertyName));
		}
	}
}