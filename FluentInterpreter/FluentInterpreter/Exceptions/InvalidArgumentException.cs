namespace FluentInterpreter.Exceptions
{
	using System;

	public class InvalidArgumentException : Exception
	{
		private const string DEFAULT_MESSAGE = "The argument provided is null or empty!";

		public InvalidArgumentException() : base(DEFAULT_MESSAGE) { }

		public InvalidArgumentException(string parameterName) : base(
			$"{DEFAULT_MESSAGE} Parameter name: {parameterName}") { }
	}
}