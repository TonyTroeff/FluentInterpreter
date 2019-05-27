namespace FluentInterpreter.Tests.Configuration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;
	using PrimaryKeys;

	public class NoteCategoryConfiguration : IEntityTypeConfiguration<NoteCategory>
	{
		public void Configure(EntityTypeBuilder<NoteCategory> builder)
		{
			builder.PrimaryKey(nc => new { nc.NoteId, nc.CategoryId });
		}
	}
}