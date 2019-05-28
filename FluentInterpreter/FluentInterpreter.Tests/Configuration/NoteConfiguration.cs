namespace FluentInterpreter.Tests.Configuration
{
	using ForeignKeys;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;
	using Tables;

	public class NoteConfiguration : IEntityTypeConfiguration<Note>
	{
		public void Configure(EntityTypeBuilder<Note> builder)
		{
			builder.Name();
			builder.OneToMany(n => n.User, u => u.Notes, n => n.UserId);
		}
	}
}