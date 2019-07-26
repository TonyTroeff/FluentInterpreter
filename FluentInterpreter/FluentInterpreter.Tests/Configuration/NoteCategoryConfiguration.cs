namespace FluentInterpreter.Tests.Configuration
{
	using DatabaseConfiguration;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;

	public class NoteCategoryConfiguration : IEntityTypeConfiguration<NoteCategory>
	{
		public void Configure(EntityTypeBuilder<NoteCategory> builder)
		{
			builder.Name();

			builder.PrimaryKey(nc => new { nc.NoteId, nc.CategoryId });

			builder.OneToMany(nc => nc.Note, n => n.Categories, nc => nc.NoteId);
			builder.OneToMany(nc => nc.Category, c => c.Notes, nc => nc.CategoryId);
		}
	}
}