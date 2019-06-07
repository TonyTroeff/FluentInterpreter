namespace FluentInterpreter.DatabaseConfiguration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using NamingConvention;

	public static class TableNameConfiguration
	{
		public static void Name<T>(this EntityTypeBuilder<T> builder)
			where T : class
		{
			Common.CheckForNull(builder);
			
			string tableName = NamingServices.TableNaming.GetTableName(typeof(T));

			builder.ToTable(tableName);
		}
	}
}