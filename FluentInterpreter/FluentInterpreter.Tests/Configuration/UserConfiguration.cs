namespace FluentInterpreter.Tests.Configuration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;
	using PrimaryKeys;

	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder) { builder.PrimaryKey(u => u.Id); }
	}
}