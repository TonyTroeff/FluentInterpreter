namespace FluentInterpreter.PropertiesConfiguration
{
	using Exceptions;
	using Microsoft.EntityFrameworkCore;
	using TypesConfiguration;

	/// <summary>
	/// Static class, containing methods for configuring an <see cref="ITypeResolver"/>.
	/// </summary>
	public static class Provider
	{
		private static ITypeResolver _typeResolver;

		/// <summary>
		/// Extension method that configures a pre-made implementation of the <see cref="ITypeResolver"/> interface.
		/// </summary>
		/// <param name="context">The implementation of the <see cref="DbContext"/> class used from the extension method to access its provider name.</param>
		/// <exception cref="NotRegisteredProvider">Thrown when no such pre-made <see cref="ITypeResolver"/> implementation exists for the current provider.</exception>
		public static void ConfigureTypeResolver(this DbContext context)
		{
			// Check for null values.
			Common.CheckForNull(context);
			
			// Obtain information about the provider.
			string providerName = context.Database.ProviderName;
			
			// Check if a pre-made ITypeResolver exists and configure it or throw an exception.
			switch (providerName)
			{
				case "Microsoft.EntityFrameworkCore.SqlServer":
					context.ConfigureTypeResolver(new SqlServerTypeResolver());
					break;
				case "Microsoft.EntityFrameworkCore.Sqlite":
					context.ConfigureTypeResolver(new SqliteTypeResolver());
					break;
				case "Npgsql.EntityFrameworkCore.PostgreSQL":
					context.ConfigureTypeResolver(new PostgreSqlTypeResolver());
					break;
				default: throw new NotRegisteredProvider(providerName);
			}
		}

		/// <summary>
		/// Extension method that configures a custom implementation of the <see cref="ITypeResolver"/> interface.
		/// </summary>
		/// <param name="context">The implementation of the <see cref="DbContext"/> class used from the extension method.</param>
		/// <param name="typeResolver">The custom implementation of the <see cref="ITypeResolver"/>.</param>
		public static void ConfigureTypeResolver(this DbContext context, ITypeResolver typeResolver)
		{
			// Check for null values.
			Common.CheckForNull(context);
			Common.CheckForNull(typeResolver);

			// Configure the new resolver.
			_typeResolver = typeResolver;
		}

		/// <summary>
		/// Method to access the value of the configured <see cref="ITypeResolver"/> implementation.
		/// </summary>
		/// <returns>The last configured <see cref="ITypeResolver"/>.</returns>
		/// <exception cref="NoProviderConfiguredException">Thrown when no <see cref="ITypeResolver"/> has been configured.</exception>
		public static ITypeResolver GetTypeResolver()
		{
			// Check if a type resolver has been configured.
			if (_typeResolver == null) throw new NoProviderConfiguredException();

			return _typeResolver;
		}
	}
}