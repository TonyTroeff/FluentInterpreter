namespace FluentInterpreter.DatabaseConfiguration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Reflection;
	using Exceptions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public static class Common
	{
		public const string GUID_TYPE = "uniqueidentifier";
		public const string BOOL_TYPE = "bit";
		public const string BYTE_TYPE = "tinyint";
		public const string DATETIME_TYPE = "datetime2";
		public const string INTEGER_TYPE = "int";

		public static string GetStringType(int length = -1, bool isUnicode = true, bool isFixedLength = false)
		{
			string type = "";

			if (isUnicode) type += "n";
			if (isFixedLength == false) type += "var";

			type += $"char({(length == -1 ? "max" : length.ToString())})";

			return type;
		}

		public static PropertyBuilder<T> Configure<T>(
			this PropertyBuilder<T> builder,
			string name,
			string type,
			bool isRequired)
			=> builder.HasColumnName(name)
				.HasColumnType(type)
				.IsRequired(isRequired);

		public static string[] GetMembers<T>(Expression<Func<T, object>> expression)
		{
			List<MemberInfo> properties = new List<MemberInfo>();

			if (expression.Body is MemberExpression memberExpression) properties.Add(memberExpression.Member);
			else if ((expression.Body as UnaryExpression)?.Operand is MemberExpression unaryExpression)
				properties.Add(unaryExpression.Member);
			else if (expression.Body is NewExpression newExpression) properties.AddRange(newExpression.Members);
			else throw new InvalidKeyExpressionException(nameof(expression));

			return properties.Select(m => m.Name)
				.ToArray();
		}
	}
}