namespace FluentInterpreter
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Reflection;
	using Exceptions;

	public static class Common
	{
		public static string[] GetMembers<T>(Expression<Func<T, object>> expression)
		{
			if (expression == null) throw new InvalidArgumentException();
			
			List<MemberInfo> properties = new List<MemberInfo>();

			if (expression.Body is MemberExpression memberExpression) properties.Add(memberExpression.Member);
			else if ((expression.Body as UnaryExpression)?.Operand is MemberExpression unaryExpression)
				properties.Add(unaryExpression.Member);
			else if (expression.Body is NewExpression newExpression) properties.AddRange(newExpression.Members);
			else throw new InvalidKeyExpressionException(nameof(expression));

			return properties.Select(m => m.Name)
				.ToArray();
		}

		public static void CheckStrings(params string[] parameters)
		{
			if (parameters == null
				|| parameters.Length <= 0
				|| parameters.Any(string.IsNullOrWhiteSpace)) throw new InvalidArgumentException();
		}

		public static void CheckForNull(object obj)
		{
			if (obj == null) throw new InvalidArgumentException();
		}

		public static void CheckMemberExpression(Expression expression)
		{
			if (expression is MemberExpression == false) throw new NotMemberExpressionException();
		}
	}
}