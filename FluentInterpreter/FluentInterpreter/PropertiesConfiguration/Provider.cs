namespace FluentInterpreter.PropertiesConfiguration
{
	using Microsoft.EntityFrameworkCore;
	using TypesConfiguration;

	public static class Provider
	{
		public static ITypeResolver TypeResolver { get; private set; }

		public static void ConfigureTypeResolver(this DbContext context)
		{
			// TODO...
			if (context.Database.ProviderName == "Microsoft.EntityFrameworkCore.SqlServer")
				TypeResolver = new SqlServerTypeResolver();
		}

		public static void ConfigureTypeResolver(this DbContext context, ITypeResolver typeResolver)
		{
			// TODO: Validation;
			TypeResolver = typeResolver;
		}
	}
}