namespace FluentInterpreter.ForeignKeys
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using Exceptions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public static class OneToManyConfiguration
	{
		public static void OneToMany<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, TPrincipal>> descendant,
			Expression<Func<TPrincipal, IEnumerable<TDescendant>>> principal,
			Expression<Func<TDescendant, object>> foreignKeyExpression)
			where TDescendant : class
			where TPrincipal : class
		{
			if (descendant.Body is MemberExpression == false)
				throw new NotMemberExpressionException(nameof(descendant));
			if (principal.Body is MemberExpression == false) throw new NotMemberExpressionException(nameof(principal));

			string[] properties = Common.GetPropertyNames(foreignKeyExpression);

			string descendantTableName = NamingServices.TableNaming.GetTableName(typeof(TDescendant));
			string principalTableName = NamingServices.TableNaming.GetTableName(typeof(TPrincipal));
			string foreignKeyName = NamingServices.ForeignKeyNaming.GetConstraintName(
				descendantTableName,
				principalTableName,
				properties);

			builder.HasOne(descendant)
				.WithMany(principal)
				.HasForeignKey(foreignKeyExpression)
				.HasConstraintName(foreignKeyName);
		}
	}
}