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

	public static class ManyToOneConfiguration
	{
		public static void ManyToOne<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principal,
			Expression<Func<TPrincipal, TDescendant>> descendant,
			Expression<Func<TPrincipal, object>> foreignKeyExpression)
			where TDescendant : class
			where TPrincipal : class
			=> builder.ManyToOne(
				principal,
				descendant,
				foreignKeyExpression,
				new DefaultTableNaming(),
				new DefaultForeignKeyNaming());

		public static void ManyToOne<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principal,
			Expression<Func<TPrincipal, TDescendant>> descendant,
			Expression<Func<TPrincipal, object>> foreignKeyExpression,
			ITableNaming tableNaming)
			where TDescendant : class
			where TPrincipal : class
			=> builder.ManyToOne(
				principal,
				descendant,
				foreignKeyExpression,
				tableNaming,
				new DefaultForeignKeyNaming());

		public static void ManyToOne<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principal,
			Expression<Func<TPrincipal, TDescendant>> descendant,
			Expression<Func<TPrincipal, object>> foreignKeyExpression,
			IForeignKeyNaming foreignKeyNaming)
			where TDescendant : class
			where TPrincipal : class
			=> builder.ManyToOne(
				principal,
				descendant,
				foreignKeyExpression,
				new DefaultTableNaming(),
				foreignKeyNaming);

		public static void ManyToOne<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principal,
			Expression<Func<TPrincipal, TDescendant>> descendant,
			Expression<Func<TPrincipal, object>> foreignKeyExpression,
			ITableNaming tableNaming,
			IForeignKeyNaming foreignKeyNaming)
			where TDescendant : class
			where TPrincipal : class
		{
			if (descendant.Body is MemberExpression == false)
				throw new NotMemberExpressionException(nameof(descendant));
			if (principal.Body is MemberExpression == false) throw new ArgumentException(nameof(principal));

			string[] foreignKeyPropertyName = Common.GetPropertyNames(foreignKeyExpression);

			string descendantTableName = tableNaming.GetTableName(typeof(TDescendant));
			string principalTableName = tableNaming.GetTableName(typeof(TPrincipal));

			builder.HasMany(principal)
				.WithOne(descendant)
				.HasForeignKey(foreignKeyExpression)
				.HasConstraintName(
					foreignKeyNaming.GetConstraintName(
						descendantTableName,
						principalTableName,
						foreignKeyPropertyName));
		}
	}
}