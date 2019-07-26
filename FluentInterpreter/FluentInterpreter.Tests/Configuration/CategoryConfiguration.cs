#region

using FluentInterpreter.DatabaseConfiguration;
using FluentInterpreter.Tests.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace FluentInterpreter.Tests.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Name();
            builder.PrimaryKey(c => c.Id);
        }
    }
}