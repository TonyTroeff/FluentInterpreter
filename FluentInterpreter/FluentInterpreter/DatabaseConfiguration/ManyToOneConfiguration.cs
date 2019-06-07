namespace FluentInterpreter.DatabaseConfiguration
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using NamingConvention;

	public static class ManyToOneConfiguration
	{
		public static ReferenceCollectionBuilder<TDependent, TPrincipal> ManyToOne<TDependent, TPrincipal>(
			this EntityTypeBuilder<TDependent> builder,
			Expression<Func<TDependent, IEnumerable<TPrincipal>>> principal,
			Expression<Func<TPrincipal, TDependent>> dependent,
			Expression<Func<TPrincipal, object>> foreignKeyExpression)
			where TDependent : class
			where TPrincipal : class
		{
			string[] properties = Common.GetMembers(foreignKeyExpression);
			return builder.ManyToOne(principal, dependent, properties);
		}

		public static ReferenceCollectionBuilder<TDependent, TPrincipal> ManyToOne<TDependent, TPrincipal>(
			this EntityTypeBuilder<TDependent> builder,
			Expression<Func<TDependent, IEnumerable<TPrincipal>>> principal,
			Expression<Func<TPrincipal, TDependent>> dependent,
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

			return builder.HasMany(principal)
				.WithOne(dependent)
				.HasForeignKey(properties)
				.HasConstraintName(foreignKeyName);
		}
	}
}