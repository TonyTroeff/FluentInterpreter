#region

using FluentInterpreter.DatabaseConfiguration;
using FluentInterpreter.Tests.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace FluentInterpreter.Tests.Configuration
{
    public class ChangeLogConfiguration : IEntityTypeConfiguration<ChangeLog>
    {
        public void Configure(EntityTypeBuilder<ChangeLog> builder)
        {
            builder.Name();
        }
    }
}