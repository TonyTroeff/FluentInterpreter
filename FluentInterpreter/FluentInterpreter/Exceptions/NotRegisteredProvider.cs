namespace FluentInterpreter.Exceptions
{
	using System;

	public class NotRegisteredProvider : Exception
	{
		private const string DEFAULT_MESSAGE =
			"A provider with that name does not have a default ITypeReslver implementation!";

		public NotRegisteredProvider(string providerName) : base($"{DEFAULT_MESSAGE} Provider name: {providerName}") { }
	}
}