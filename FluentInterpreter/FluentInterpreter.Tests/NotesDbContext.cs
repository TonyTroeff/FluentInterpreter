using System.IO;

namespace FluentInterpreter.Tests
{
	using Configuration;
	using Microsoft.EntityFrameworkCore;
	using PropertiesConfiguration;

	public sealed class NotesDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseNpgsql(ReadConnectionString("postgresql"));

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			this.ConfigureTypeResolver();

			modelBuilder.ApplyConfiguration(new NoteConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new NoteCategoryConfiguration());
		}

		private static string ReadConnectionString(string filename) => File.ReadAllText($"../../../{filename}.con");
	}
}
