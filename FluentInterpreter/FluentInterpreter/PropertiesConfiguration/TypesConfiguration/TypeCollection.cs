#region

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace FluentInterpreter.PropertiesConfiguration.TypesConfiguration
{
    public class TypeCollection : IEnumerable<KeyValuePair<Type, string>>
    {
        private readonly Dictionary<Type, string> _types = new Dictionary<Type, string>();

        public IEnumerator<KeyValuePair<Type, string>> GetEnumerator()
        {
            return _types.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Type type, string name)
        {
            Common.CheckForNull(type);
            Common.CheckStrings(name);

            _types[type] = name;
        }

        public string GetType(Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;

            return _types[type.IsEnum ? Enum.GetUnderlyingType(type) : type];
        }
    }
}