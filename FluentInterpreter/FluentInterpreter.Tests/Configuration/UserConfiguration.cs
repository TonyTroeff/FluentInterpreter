namespace FluentInterpreter.Tests.Configuration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;
	using PrimaryKeys;
	using Tables;
	using UniqueIndexes;

	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Name();
			builder.PrimaryKey(u => u.Id);
			builder.Unique(u => u.Username);
		}
	}
}