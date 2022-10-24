using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public abstract class BaseRepository<T>
        where T : class
    {
        protected static SqlConexion sql = SqlConexion.GetSqlConnection();

        protected T[] BuildGetAll(SqlCommand cmd)
        {
            var entities = new List<T>();

            sql.SqlExecute(() =>
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read()) entities.Add(MapResponse(ref reader));
            });

            return entities.ToArray();
        }

        protected T BuildGetOne(string command, int id)
        {
            var cmd = sql.BuildCommand(command);
            cmd.Parameters.AddWithValue("@id", id);

            T entity = null;

            sql.SqlExecute(() =>
            {
                var reader = cmd.ExecuteReader();
                if (reader.Read()) entity = MapResponse(ref reader);
            });

            return entity;
        }

        protected T[] BuildGetAll(string command)
        {
            var cmd = sql.BuildCommand(command);
            return BuildGetAll(cmd);
        }

        protected bool BuildUpdate(string command, ref T entity)
        {
            var cmd = sql.BuildCommand(command);
            MapRequest(ref cmd, ref entity);

            return sql.SqlExecute(() => cmd.ExecuteNonQuery());
        }

        protected bool BuildCreate(string command, ref T entity)
        {
            var cmd = sql.BuildCommand(command);
            MapRequest(ref cmd, ref entity);

            return sql.SqlExecute(() => cmd.ExecuteNonQuery());
        }

        protected bool BuildDelete(string command, int id)
        {
            var cmd = sql.BuildCommand(command);
            cmd.Parameters.AddWithValue("@id", id);

            return sql.SqlExecute(() => cmd.ExecuteNonQuery());
        }

        protected abstract void MapRequest(ref SqlCommand cmd, ref T entity);
        protected abstract T MapResponse(ref SqlDataReader reader);
    }
}
