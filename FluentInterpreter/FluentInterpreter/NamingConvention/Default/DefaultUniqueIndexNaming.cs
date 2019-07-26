namespace FluentInterpreter.NamingConvention.Default
{
    public class DefaultUniqueIndexNaming : IUniqueIndexNaming
    {
        public string GetConstraintName(string tableName, string[] properties)
        {
            Common.CheckStrings(tableName);
            Common.CheckStrings(properties);

            return
                $"{Convention.UNIQUE_INDEX_PREFIX}{Convention.DELIMITER}{tableName}{Convention.DELIMITER}{string.Join(Convention.DELIMITER, properties)}";
        }
    }
}