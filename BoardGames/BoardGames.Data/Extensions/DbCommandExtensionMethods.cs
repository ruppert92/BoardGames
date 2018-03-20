using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BoardGames.Data.Extensions
{
    public static class DbCommandExtensionMethods
    {
        public static void AddParameter(this IDbCommand command, string name, DbType type, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.DbType = type;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }

        public static void Page(this IDbCommand command, int pageNumber, int pageSize)
        {
            if (command.GetType() == typeof(MySqlConnection))
            {
                int start = pageNumber * pageSize;

                command.CommandText = String.Format("{0} LIMIT {1}, {2}", command.CommandText, start, pageSize);
            }
        }
    }
}
