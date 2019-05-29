namespace FluentInterpreter
{
	using ForeignKeys.NamingConvention;
	using Indexes.NamingConvention;
	using PrimaryKeys.NamingConvention;
	using Tables.NamingConvention;

	public static class NamingServices
	{
		public static IForeignKeyNaming ForeignKeyNaming { get; set; } = new DefaultForeignKeyNaming();
		public static IIndexNaming IndexNaming { get; set; } = new DefaultIndexNaming();
		public static IPrimaryKeyNaming PrimaryKeyNaming { get; set; } = new DefaultPrimaryKeyNaming();
		public static ITableNaming TableNaming { get; set; } = new DefaultTableNaming();
	}
}