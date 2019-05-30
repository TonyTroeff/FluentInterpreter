namespace FluentInterpreter.PropertiesConfiguration.TypesConfiguration
{
	using System;

	public class TypeInfo
	{
		public Type Type { get; }
		public string Name { get; }

		public TypeInfo(Type type, string name)
		{
			this.Type = type;
			this.Name = name;
		}
	}
}