namespace FluentInterpreter.Tests.Configuration
{
	using ForeignKeys;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;
	using PrimaryKeys;

	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.PrimaryKey(u => u.UserId);
			builder.ManyToOne(u => u.Notes, n => n.User, n => n.UserId);
		}
	}
}