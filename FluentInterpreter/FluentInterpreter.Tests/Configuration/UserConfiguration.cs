namespace FluentInterpreter.Tests.Configuration
{
	using DatabaseConfiguration;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;
	using PropertiesConfiguration;

	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Name();
			builder.PrimaryKey(u => u.Id);
			builder.Unique(u => u.Username);
			builder.Property(u => u.Profile)
				.Name()
				.DefinedType();
			builder.Property(u => u.Age)
				.Name()
				.DefinedType();
		}
	}
}