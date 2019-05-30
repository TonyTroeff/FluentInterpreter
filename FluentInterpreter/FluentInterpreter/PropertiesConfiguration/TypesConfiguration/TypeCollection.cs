namespace FluentInterpreter.PropertiesConfiguration.TypesConfiguration
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	public class TypeCollection : IEnumerable<TypeInfo>
	{
		private readonly List<TypeInfo> _types = new List<TypeInfo>();

		public void Add(Type type, string name)
		{
			// TODO: Validation.

			TypeInfo typeInfo = this._types.SingleOrDefault(ti => ti.Type == type);

			if (typeInfo != null) this._types.Remove(typeInfo);
			else typeInfo = new TypeInfo(type, name);

			this._types.Add(typeInfo);
		}

		public string GetTypeName(Type type)
			=> this._types.SingleOrDefault(ti => ti.Type == type)
				?.Name;

		public IEnumerator<TypeInfo> GetEnumerator() => this._types.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
	}
}