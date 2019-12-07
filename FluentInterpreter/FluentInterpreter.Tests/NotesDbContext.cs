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
            optionsBuilder.UseSqlServer(ReadConnectionString("sqlserver"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ConfigureTypeResolver();

            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new NoteCategoryConfiguration());
        }

        private static string ReadConnectionString(string filename)
        {
            return File.ReadAllText($"../../../{filename}.con");
        }
    }
}