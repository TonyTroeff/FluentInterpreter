namespace FluentInterpreter.Exceptions
{
	using System;

	public class InvalidKeyExpressionException : Exception
	{
		private const string DEFAULT_MESSAGE =
			"The expression provided should be a MemberExpression or a NewExpression in order to obtain information about the properties that form the key!";

		public InvalidKeyExpressionException() : base(DEFAULT_MESSAGE) { }

		public InvalidKeyExpressionException(string parameterName) : base(
			$"{DEFAULT_MESSAGE} Parameter name: {parameterName}") { }
	}
}