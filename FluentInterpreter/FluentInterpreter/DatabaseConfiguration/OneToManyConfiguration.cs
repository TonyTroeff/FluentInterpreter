namespace FluentInterpreter.DatabaseConfiguration
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using Exceptions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using NamingConvention;

	public static class OneToManyConfiguration
	{
		public static ReferenceCollectionBuilder<TPrincipal, TDependent> OneToMany<TDependent, TPrincipal>(
			this EntityTypeBuilder<TDependent> builder,
			Expression<Func<TDependent, TPrincipal>> dependent,
			Expression<Func<TPrincipal, IEnumerable<TDependent>>> principal,
			Expression<Func<TDependent, object>> foreignKeyExpression)
			where TDependent : class
			where TPrincipal : class
		{
			string[] properties = Common.GetMembers(foreignKeyExpression);
			return builder.OneToMany(dependent, principal, properties);
		}

		public static ReferenceCollectionBuilder<TPrincipal, TDependent> OneToMany<TDependent, TPrincipal>(
			this EntityTypeBuilder<TDependent> builder,
			Expression<Func<TDependent, TPrincipal>> dependent,
			Expression<Func<TPrincipal, IEnumerable<TDependent>>> principal,
			params string[] properties)
			where TDependent : class
			where TPrincipal : class
		{
			if (dependent.Body is MemberExpression == false) throw new NotMemberExpressionException(nameof(dependent));
			if (principal.Body is MemberExpression == false) throw new NotMemberExpressionException(nameof(principal));

			string dependentTableName = NamingServices.TableNaming.GetTableName(typeof(TDependent));
			string principalTableName = NamingServices.TableNaming.GetTableName(typeof(TPrincipal));
			string foreignKeyName = NamingServices.ForeignKeyNaming.GetConstraintName(
				dependentTableName,
				principalTableName,
				properties);

			return builder.HasOne(dependent)
				.WithMany(principal)
				.HasForeignKey(properties)
				.HasConstraintName(foreignKeyName);
		}
	}
}