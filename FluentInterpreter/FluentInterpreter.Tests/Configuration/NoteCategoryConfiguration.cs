#region

using FluentInterpreter.DatabaseConfiguration;
using FluentInterpreter.Tests.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace FluentInterpreter.Tests.Configuration
{
    public class NoteCategoryConfiguration : IEntityTypeConfiguration<NoteCategory>
    {
        public void Configure(EntityTypeBuilder<NoteCategory> builder)
        {
            builder.Name();

            builder.PrimaryKey(nc => new {nc.NoteId, nc.CategoryId});

            builder.OneToMany(nc => nc.Note, n => n.Categories, nc => nc.NoteId);
            builder.OneToMany(nc => nc.Category, c => c.Notes, nc => nc.CategoryId);
        }
    }
}