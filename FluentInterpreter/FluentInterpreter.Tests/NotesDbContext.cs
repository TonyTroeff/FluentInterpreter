namespace FluentInterpreter.Tests
{
	using Configuration;
	using Microsoft.EntityFrameworkCore;
	using PropertiesConfiguration;

	public sealed class NotesDbContext : DbContext
	{
		public NotesDbContext() { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlServer(@"Server = .\SQLEXPRESS; Database = Notes; Integrated Security = True");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			this.ConfigureTypeResolver();

			modelBuilder.ApplyConfiguration(new NoteConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new NoteCategoryConfiguration());
		}
	}
}