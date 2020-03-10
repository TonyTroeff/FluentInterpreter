#region

using System;
using Humanizer;

#endregion

namespace FluentInterpreter.NamingConvention.Default
{
    public class DefaultTableNaming : ITableNaming
    {
        public string GetTableName(Type type)
        {
            Common.CheckForNull(type);

            return type.Name.Pluralize(false);
        }
    }
}