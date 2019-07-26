#region

using Humanizer;

#endregion

namespace FluentInterpreter.NamingConvention.Default
{
    public class DefaultColumnNaming : IColumnNaming
    {
        public string GetColumnName(string propertyName)
        {
            Common.CheckStrings(propertyName);

            return propertyName.Pascalize();
        }
    }
}