namespace FluentInterpreter.Exceptions
{
	using System;

	public class NotMemberExpressionException : Exception
	{
		private const string DEFAULT_MESSAGE = "The expression provided is not a MemberExpression!";

		public NotMemberExpressionException() : base(DEFAULT_MESSAGE) { }

		public NotMemberExpressionException(string parameterName) : base(
			$"{DEFAULT_MESSAGE} Parameter name: {parameterName}") { }
	}
}