namespace FluentInterpreter.DatabaseConfiguration
{
    using System;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NamingConvention;

    public static class PrimaryKeyConfiguration
    {
        public static KeyBuilder PrimaryKey<T>(
            this EntityTypeBuilder<T> builder,
            Expression<Func<T, object>> primaryKeyExpression)
            where T : class
        {
            string[] properties = Common.GetMembers(primaryKeyExpression);
            return builder.PrimaryKey(properties);
        }

        public static KeyBuilder PrimaryKey<T>(this EntityTypeBuilder<T> builder, params string[] properties)
            where T : class
        {
            Common.CheckForNull(builder);
            Common.CheckStrings(properties);

            string tableName = NamingServices.TableNaming.GetTableName(typeof(T));
            string primaryKeyName = NamingServices.PrimaryKeyNaming.GetConstraintName(tableName, properties);

            KeyBuilder keyBuilder = builder.HasKey(properties)
                .HasName(primaryKeyName);

            for (int i = 1; i < properties.Length; i++) builder.Index(properties[i]);

            return keyBuilder;
        }
    }
}