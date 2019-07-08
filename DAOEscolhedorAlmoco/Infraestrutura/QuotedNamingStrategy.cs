using NHibernate.Cfg;

namespace DAOEscolhedorAlmoco.Infraestrutura
{
    internal class QuotedNamingStrategy : INamingStrategy
    {
        public string ClassToTableName(string className)
        {
            return className;
        }

        public string PropertyToColumnName(string propertyName)
        {
            return string.Format("\"{0}\"", propertyName);
        }

        public string TableName(string tableName)
        {
            if (tableName[0] == '`')
            {
                tableName = tableName.Substring(1, tableName.Length - 2);
            }

            tableName = string.Format("\"{0}\"", tableName);

            return tableName;
        }

        public string ColumnName(string columnName)
        {
            return string.Format("\"{0}\"", columnName);
        }

        public string PropertyToTableName(string className, string propertyName)
        {
            return propertyName;
        }

        public string LogicalColumnName(string columnName, string propertyName)
        {
            return propertyName;
        }
    }
}
