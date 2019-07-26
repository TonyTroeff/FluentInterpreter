namespace FluentInterpreter.Exceptions
{
	using System;

	public class InvalidArgumentException : Exception
	{
		private const string DEFAULT_MESSAGE = "The argument is null or empty!";

		public InvalidArgumentException() : base(DEFAULT_MESSAGE) { }
	}
}