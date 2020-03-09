#region

using System;
using System.Linq;
using FluentInterpreter.NamingConvention;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace FluentInterpreter.DatabaseConfiguration
{
    public static class TableNameConfiguration
    {
        public static void Name<T>(this EntityTypeBuilder<T> builder)
            where T : class
        {
            Common.CheckForNull(builder);

            string tableName = NamingServices.TableNaming.GetTableName(typeof(T));

            builder.ToTable(tableName);
        }

        public static void Name<T>(this EntityTypeBuilder<T> builder, params Type[] connectedTypes)
            where T : class
        {
            Common.CheckForNull(builder);

            string tableName = string.Join(string.Empty, connectedTypes.Select(ct => NamingServices.TableNaming.GetTableName(ct)));

            builder.ToTable(tableName);
        }
    }
}