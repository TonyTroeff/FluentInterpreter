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
			string providerName = context.Database.ProviderName;
			
			switch (providerName)
			{
				// TODO: Create ITypeResolver implementations for other providers and add them to a switch.
				case "Microsoft.EntityFrameworkCore.SqlServer":
					context.ConfigureTypeResolver(new SqlServerTypeResolver());
					break;
				default: throw new NotRegisteredProvider(providerName);
			}
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