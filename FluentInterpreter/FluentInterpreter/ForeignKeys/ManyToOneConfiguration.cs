namespace FluentInterpreter.ForeignKeys
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using Exceptions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public static class ManyToOneConfiguration
	{
		public static void ManyToOne<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principal,
			Expression<Func<TPrincipal, TDescendant>> descendant,
			Expression<Func<TPrincipal, object>> foreignKeyExpression)
			where TDescendant : class
			where TPrincipal : class
		{
			string[] properties = Common.GetMembers(foreignKeyExpression);
			builder.ManyToOne(principal,descendant,properties);
		}
		
		public static void ManyToOne<TDescendant, TPrincipal>(
			this EntityTypeBuilder<TDescendant> builder,
			Expression<Func<TDescendant, IEnumerable<TPrincipal>>> principal,
			Expression<Func<TPrincipal, TDescendant>> descendant,
			params string[] properties)
			where TDescendant : class
			where TPrincipal : class
		{
			if (descendant.Body is MemberExpression == false)
				throw new NotMemberExpressionException(nameof(descendant));
			if (principal.Body is MemberExpression == false) throw new ArgumentException(nameof(principal));

			string descendantTableName = NamingServices.TableNaming.GetTableName(typeof(TDescendant));
			string principalTableName = NamingServices.TableNaming.GetTableName(typeof(TPrincipal));
			string foreignKeyName = NamingServices.ForeignKeyNaming.GetConstraintName(
				descendantTableName,
				principalTableName,
				properties);

			builder.HasMany(principal)
				.WithOne(descendant)
				.HasForeignKey(properties)
				.HasConstraintName(foreignKeyName);
		}
	}
}