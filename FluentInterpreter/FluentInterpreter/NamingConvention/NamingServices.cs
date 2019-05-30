namespace FluentInterpreter.NamingConvention
{
	using Default;

	public static class NamingServices
	{
		public static IForeignKeyNaming ForeignKeyNaming { get; set; } = new DefaultForeignKeyNaming();
		public static IIndexNaming IndexNaming { get; set; } = new DefaultIndexNaming();
		public static IPropertyNaming PropertyNaming { get; set; } = new DefaultPropertyNaming();
		public static IUniqueIndexNaming UniqueIndexNaming { get; set; } = new DefaultUniqueIndexNaming();
		public static IPrimaryKeyNaming PrimaryKeyNaming { get; set; } = new DefaultPrimaryKeyNaming();
		public static ITableNaming TableNaming { get; set; } = new DefaultTableNaming();
	}
}