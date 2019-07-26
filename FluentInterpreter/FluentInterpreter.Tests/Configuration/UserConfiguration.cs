#region

using FluentInterpreter.DatabaseConfiguration;
using FluentInterpreter.PropertiesConfiguration;
using FluentInterpreter.Tests.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace FluentInterpreter.Tests.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Name();
            builder.PrimaryKey(u => u.Id);
            builder.Unique(u => u.Username);
            builder.Property(u => u.Profile)
                .Name()
                .ResolveType()
                .Default(Profile.Common);

            builder.Property(u => u.Age)
                .Name()
                .ResolveType();
        }
    }
}