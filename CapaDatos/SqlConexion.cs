using CapaDatos.Properties;
using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class SqlConexion
    {
        private static SqlConexion sqlConnection;

        public static SqlConexion GetSqlConnection()
        {
            if (sqlConnection == null) sqlConnection = new SqlConexion();
            return sqlConnection;
        }

        private readonly SqlConnection sql = new SqlConnection(Settings.Default.ConnectionString);

        public SqlCommand BuildCommand(string command)
        {
            return new SqlCommand
            {
                CommandText = command,
                Connection = sql,
                CommandType = System.Data.CommandType.StoredProcedure
            };
        }

        public bool SqlExecute(Action action)
        {
            bool success;

            try
            {
                sql.Open();
                action();
                sql.Close();

                success = true;
            }
            catch
            {
                success = false;    
            }

            return success;
        }
    }
}
