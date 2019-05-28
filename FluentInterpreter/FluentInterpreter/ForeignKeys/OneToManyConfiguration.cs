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
			Expression<Func<TDescendant, TPrincipal>> descendant,
			Expression<Func<TPrincipal, IEnumerable<TDescendant>>> principal,
			Expression<Func<TDescendant, object>> foreignKeyExpression)
			where TDescendant : class
			where TPrincipal : class
			=> builder.OneToMany(
				descendant,
				principal,
				foreignKeyExpression,
				new DefaultTableNaming(),
				new DefaultForeignKeyNaming());

		public static void OneToMany<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, TPrincipal>> descendant,
			Expression<Func<TPrincipal, IEnumerable<TDescendant>>> principal,
			Expression<Func<TDescendant, object>> foreignKeyExpression,
			ITableNaming tableNaming)
			where TDescendant : class
			where TPrincipal : class
			=> builder.OneToMany(
				descendant,
				principal,
				foreignKeyExpression,
				tableNaming,
				new DefaultForeignKeyNaming());

		public static void OneToMany<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, TPrincipal>> descendant,
			Expression<Func<TPrincipal, IEnumerable<TDescendant>>> principal,
			Expression<Func<TDescendant, object>> foreignKeyExpression,
			IForeignKeyNaming foreignKeyNaming)
			where TDescendant : class
			where TPrincipal : class
			=> builder.OneToMany(
				descendant,
				principal,
				foreignKeyExpression,
				new DefaultTableNaming(),
				foreignKeyNaming);

		public static void OneToMany<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, TPrincipal>> descendant,
			Expression<Func<TPrincipal, IEnumerable<TDescendant>>> principal,
			Expression<Func<TDescendant, object>> foreignKeyExpression,
			ITableNaming tableNaming,
			IForeignKeyNaming foreignKeyNaming)
			where TDescendant : class
			where TPrincipal : class
		{
			if (descendant.Body is MemberExpression == false)
				throw new NotMemberExpressionException(nameof(descendant));
			if (principal.Body is MemberExpression == false) throw new NotMemberExpressionException(nameof(principal));

			string[] foreignKeyPropertyName = Common.GetPropertyNames(foreignKeyExpression);

			string descendantTableName = tableNaming.GetTableName(typeof(TDescendant));
			string principalTableName = tableNaming.GetTableName(typeof(TPrincipal));

			builder.HasOne(descendant)
				.WithMany(principal)
				.HasForeignKey(foreignKeyExpression)
				.HasConstraintName(
					foreignKeyNaming.GetConstraintName(
						descendantTableName,
						principalTableName,
						foreignKeyPropertyName));
		}
	}
}