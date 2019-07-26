#region

using System;

#endregion

namespace FluentInterpreter.NamingConvention
{
    public interface ITableNaming
    {
        string GetTableName(Type type);
    }
}