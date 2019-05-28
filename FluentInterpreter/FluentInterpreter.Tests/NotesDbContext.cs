namespace FluentInterpreter.Tests
{
	using Configuration;
	using Microsoft.EntityFrameworkCore;

	public class NotesDbContext : DbContext
	{
		public NotesDbContext() { }
		public NotesDbContext(DbContextOptions options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlServer(@"Server = .\SQLEXPRESS; Database = Notes; Integrated Security = True");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new NoteConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new NoteCategoryConfiguration());
		}
	}
}