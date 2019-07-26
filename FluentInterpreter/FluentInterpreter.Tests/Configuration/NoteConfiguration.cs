#region

using FluentInterpreter.DatabaseConfiguration;
using FluentInterpreter.PropertiesConfiguration;
using FluentInterpreter.Tests.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace FluentInterpreter.Tests.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.Name();
            builder.PrimaryKey(n => n.Id);
            builder.OneToMany(n => n.User, u => u.Notes, n => n.UserId);

            builder.Property(n => n.Text)
                .Name()
                .StringType();

            builder.Property(n => n.Created)
                .Name()
                .ResolveType();
        }
    }
}