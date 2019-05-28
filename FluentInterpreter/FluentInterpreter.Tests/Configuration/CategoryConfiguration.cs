namespace FluentInterpreter.Tests.Configuration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;
	using PrimaryKeys;
	using Tables;

	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Name();
			builder.PrimaryKey(c => c.Id);
		}
	}
}