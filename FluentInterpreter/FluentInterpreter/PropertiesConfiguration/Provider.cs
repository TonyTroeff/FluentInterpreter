namespace FluentInterpreter.PropertiesConfiguration
{
	using System;
	using Exceptions;
	using Microsoft.EntityFrameworkCore;
	using TypesConfiguration;

	public static class Provider
	{
		private static ITypeResolver _typeResolver;

		public static void ConfigureTypeResolver(this DbContext context)
		{
			// TODO Create ITypeResolver implementations for other providers and add them to a switch.
			if (context.Database.ProviderName == "Microsoft.EntityFrameworkCore.SqlServer")
				_typeResolver = new SqlServerTypeResolver();
		}

		public static void ConfigureTypeResolver(this DbContext context, ITypeResolver typeResolver)
			=> _typeResolver = typeResolver ?? throw new ArgumentNullException(nameof(typeResolver));

		public static ITypeResolver GetTypeResolver()
		{
			if (_typeResolver == null) throw new NoProviderConfiguredException();

			return _typeResolver;
		}
	}
}