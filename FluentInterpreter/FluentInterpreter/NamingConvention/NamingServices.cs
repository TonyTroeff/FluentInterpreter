namespace FluentInterpreter.NamingConvention
{
	using Default;

	public static class NamingServices
	{
		public static IForeignKeyNaming ForeignKeyNaming { get; set; } = new DefaultForeignKeyNaming();
		public static IIndexNaming IndexNaming { get; set; } = new DefaultIndexNaming();
		public static IColumnNaming ColumnNaming { get; set; } = new DefaultColumnNaming();
		public static IUniqueIndexNaming UniqueIndexNaming { get; set; } = new DefaultUniqueIndexNaming();
		public static IPrimaryKeyNaming PrimaryKeyNaming { get; set; } = new DefaultPrimaryKeyNaming();
		public static ITableNaming TableNaming { get; set; } = new DefaultTableNaming();
	}
}