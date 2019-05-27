namespace FluentInterpreter
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using Exceptions;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public static class Common
	{
		public const string INDEX_PREFIX = "IX";
		public const string UNIQUE_CONSTRAINT_PREFIX = "U";

		public const string GUID_TYPE = "uniqueidentifier";
		public const string BOOL_TYPE = "bit";
		public const string BYTE_TYPE = "tinyint";
		public const string DATETIME_TYPE = "datetime2";
		public const string INTEGER_TYPE = "int";

		public static string GetUniqueConstraintName(string tableName, string propertyName)
			=> $"{UNIQUE_CONSTRAINT_PREFIX}{Convention.DELIMITER}{tableName}{Convention.DELIMITER}{propertyName}";

		public static string GetIndexConstraintName(string tableName, string propertyName)
			=> $"{INDEX_PREFIX}{Convention.DELIMITER}{tableName}{Convention.DELIMITER}{propertyName}";

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

		public static string[] GetPropertyNames<T>(Expression<Func<T, object>> keyExpression)
		{
			List<string> propertyNames = new List<string>();

			if ((keyExpression.Body as UnaryExpression)?.Operand is MemberExpression memberExpression)
				propertyNames.Add(memberExpression.Member.Name);
			else if (keyExpression.Body is NewExpression newExpression)
				propertyNames.AddRange(newExpression.Members.Select(m => m.Name));
			else throw new InvalidKeyExpressionException(nameof(keyExpression));

			return propertyNames.ToArray();
		}
	}
}