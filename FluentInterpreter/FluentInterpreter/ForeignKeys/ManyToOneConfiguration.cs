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
		public static void ManyToOne<TDescendant, TPrincipal, TForeignKey>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principalNavigationPropertyExpression,
			Expression<Func<TPrincipal, TDescendant>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, TForeignKey>> foreignKeyPropertyExpression)
			where TDescendant : class
			where TPrincipal : class
			=> builder.ManyToOne(
				principalNavigationPropertyExpression,
				descendantNavigationPropertyExpression,
				foreignKeyPropertyExpression,
				new DefaultTableNaming(),
				new DefaultForeignKeyNaming());

		public static void ManyToOne<TDescendant, TPrincipal, TForeignKey>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principalNavigationPropertyExpression,
			Expression<Func<TPrincipal, TDescendant>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, TForeignKey>> foreignKeyPropertyExpression,
			ITableNaming tableNaming)
			where TDescendant : class
			where TPrincipal : class
			=> builder.ManyToOne(
				principalNavigationPropertyExpression,
				descendantNavigationPropertyExpression,
				foreignKeyPropertyExpression,
				tableNaming,
				new DefaultForeignKeyNaming());

		public static void ManyToOne<TDescendant, TPrincipal, TForeignKey>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principalNavigationPropertyExpression,
			Expression<Func<TPrincipal, TDescendant>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, TForeignKey>> foreignKeyPropertyExpression,
			IForeignKeyNaming foreignKeyNaming)
			where TDescendant : class
			where TPrincipal : class
			=> builder.ManyToOne(
				principalNavigationPropertyExpression,
				descendantNavigationPropertyExpression,
				foreignKeyPropertyExpression,
				new DefaultTableNaming(),
				foreignKeyNaming);

		public static void ManyToOne<TDescendant, TPrincipal, TForeignKey>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principalNavigationPropertyExpression,
			Expression<Func<TPrincipal, TDescendant>> descendantNavigationPropertyExpression,
			Expression<Func<TPrincipal, TForeignKey>> foreignKeyPropertyExpression,
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

			builder.HasMany(principalNavigationPropertyExpression)
				.WithOne(descendantNavigationPropertyExpression)
				.HasForeignKey(
					Expression.Lambda<Func<TPrincipal, object>>(
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