using CapaDatos.Properties;
using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class SqlConexion
    {
        private static SqlConexion sqlConnection;
        private static int[] AllowedSqlExceptions = { 2061, 2627 };

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
            bool success = false;

            try
            {
                sql.Open();
                action();
                sql.Close();
                success = true;
            }
            catch (SqlException e) {
                var notAllowedError = true;

                foreach(var code in AllowedSqlExceptions) 
                    if (e.Number == code)
                    {
                        notAllowedError = false;
                        ErrorHandle(out success);
                    }

                if (notAllowedError) throw e;
            }
            catch (InvalidOperationException) { ErrorHandle(out success); }

            return success;
        }

        private void ErrorHandle(out bool success)
        {
            success = false;
        }
    }
}
