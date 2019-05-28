namespace FluentInterpreter.Tables
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using NamingConvention;

	public static class TableNameConfiguration
	{
		public static void Name<T>(this EntityTypeBuilder<T> builder)
			where T : class
			=> builder.Name(new DefaultTableNaming());

		public static void Name<T>(this EntityTypeBuilder<T> builder, ITableNaming tableNaming)
			where T : class
		{
			string tableName = tableNaming.GetTableName(typeof(T));

			builder.ToTable(tableName);
		}
	}
}