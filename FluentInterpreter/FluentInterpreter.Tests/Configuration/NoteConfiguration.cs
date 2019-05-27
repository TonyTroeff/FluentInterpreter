namespace FluentInterpreter.Tests.Configuration
{
	using ForeignKeys;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;

	public class NoteConfiguration : IEntityTypeConfiguration<Note>
	{
		public void Configure(EntityTypeBuilder<Note> builder)
			=> builder.OneToMany(n => n.User, u => u.Notes, n => new { n.UserId, n.Text });
	}
}