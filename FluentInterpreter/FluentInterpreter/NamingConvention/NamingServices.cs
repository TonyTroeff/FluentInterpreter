namespace FluentInterpreter.NamingConvention
{
	using Default;

	public static class NamingServices
	{
		private static IForeignKeyNaming _foreignKeyNaming = new DefaultForeignKeyNaming();
		private static IIndexNaming _indexNaming = new DefaultIndexNaming();
		private static IColumnNaming _columnNaming = new DefaultColumnNaming();
		private static IUniqueIndexNaming _uniqueIndexNaming = new DefaultUniqueIndexNaming();
		private static IPrimaryKeyNaming _primaryKeyNaming = new DefaultPrimaryKeyNaming();
		private static ITableNaming _tableNaming = new DefaultTableNaming();

		public static IForeignKeyNaming ForeignKeyNaming
		{
			get
			{
				Common.CheckForNull(_foreignKeyNaming);
				return _foreignKeyNaming;
			}
			set
			{
				Common.CheckForNull(value);
				_foreignKeyNaming = value;
			}
		}

		public static IIndexNaming IndexNaming
		{
			get
			{
				Common.CheckForNull(_indexNaming);
				return _indexNaming;
			}
			set
			{
				Common.CheckForNull(value);
				_indexNaming = value;
			}
		}

		public static IColumnNaming ColumnNaming
		{
			get
			{
				Common.CheckForNull(_columnNaming);
				return _columnNaming;
			}
			set
			{
				Common.CheckForNull(value);
				_columnNaming = value;
			}
		}

		public static IUniqueIndexNaming UniqueIndexNaming
		{
			get
			{
				Common.CheckForNull(_uniqueIndexNaming);
				return _uniqueIndexNaming;
			}
			set
			{
				Common.CheckForNull(value);
				_uniqueIndexNaming = value;
			}
		}

		public static IPrimaryKeyNaming PrimaryKeyNaming
		{
			get
			{
				Common.CheckForNull(_primaryKeyNaming);
				return _primaryKeyNaming;
			}
			set
			{
				Common.CheckForNull(value);
				_primaryKeyNaming = value;
			}
		}

		public static ITableNaming TableNaming
		{
			get
			{
				Common.CheckForNull(_tableNaming);
				return _tableNaming;
			}
			set
			{
				Common.CheckForNull(value);
				_tableNaming = value;
			}
		}
	}
}