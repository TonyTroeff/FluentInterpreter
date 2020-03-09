#region

using System.IO;
using FluentInterpreter.PropertiesConfiguration;
using FluentInterpreter.Tests.Configuration;
using Microsoft.EntityFrameworkCore;

#endregion

namespace FluentInterpreter.Tests
{
    public sealed class NotesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ReadConnectionString("postgresql"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ConfigureTypeResolver();

            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new NoteCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ChangeLogConfiguration());
        }

        private static string ReadConnectionString(string filename)
        {
            return File.ReadAllText($"../../../{filename}.con");
        }
    }
}