namespace FluentInterpreter.Tests.Configuration
{
	using DatabaseConfiguration;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;

	public class NoteConfiguration : IEntityTypeConfiguration<Note>
	{
		public void Configure(EntityTypeBuilder<Note> builder)
		{
			builder.Name();
			builder.PrimaryKey(n => n.Id);
			builder.OneToMany(n => n.User, u => u.Notes, n => n.UserId);
		}
	}
}