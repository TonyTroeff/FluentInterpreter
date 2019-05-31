namespace FluentInterpreter.Exceptions
{
	using System;

	public class NoProviderConfiguredException : Exception
	{
		private const string DEFAULT_MESSAGE = "A provider has not been configured!";

		public NoProviderConfiguredException() : base(DEFAULT_MESSAGE) { }
	}
}