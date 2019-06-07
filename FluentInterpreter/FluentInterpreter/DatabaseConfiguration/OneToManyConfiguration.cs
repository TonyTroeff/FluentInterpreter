namespace FluentInterpreter.DatabaseConfiguration
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
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
			Common.CheckForNull(builder);
			Common.CheckStrings(properties);
			Common.CheckMemberExpression(dependent.Body);
			Common.CheckMemberExpression(principal.Body);

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