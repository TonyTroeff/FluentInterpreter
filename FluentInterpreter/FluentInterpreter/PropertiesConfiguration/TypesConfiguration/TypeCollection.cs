namespace FluentInterpreter.PropertiesConfiguration.TypesConfiguration
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class TypeCollection : IEnumerable<KeyValuePair<Type, string>>
	{
		private readonly Dictionary<Type, string> _types = new Dictionary<Type, string>();

		public IEnumerator<KeyValuePair<Type, string>> GetEnumerator() => this._types.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

		public void Add(Type type, string name)
		{
			Common.CheckForNull(type);
			Common.CheckStrings(name);

			this._types[type] = name;
		}

		public string GetType(Type type)
		{
			type = Nullable.GetUnderlyingType(type) ?? type;

			return this._types[type.IsEnum ? Enum.GetUnderlyingType(type) : type];
		}
	}
}