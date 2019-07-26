namespace FluentInterpreter.NamingConvention.Default
{
    public class DefaultForeignKeyNaming : IForeignKeyNaming
    {
        public string GetConstraintName(string dependentTable, string principalTable, string[] columns)
        {
            Common.CheckStrings(dependentTable, principalTable);
            Common.CheckStrings(columns);

            return
                $"{Convention.FOREIGN_KEY_PREFIX}{Convention.DELIMITER}{dependentTable}{Convention.DELIMITER}{principalTable}{Convention.DELIMITER}{string.Join(Convention.DELIMITER, columns)}";
        }
    }
}