using Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class VisitRepository
    {
        private SqlConexion conexion = SqlConexion.GetSqlConnection();

        private Visit MapRequest(ref SqlDataReader reader)
        {
            return new Visit
            {
                idVisita = reader.GetInt32(0),
                idMascota = reader.GetInt32(1),
                observaciones = reader.GetString(2),
                idDoctor = reader.GetInt32(3),
                nombreDoctor = reader.GetString(4),
                fechaVisita = reader.GetDateTime(5),
                tipoVisita = reader.GetString(6),
            };
        }

        public Visit[] GetAll()
        {
            var cmd = conexion.BuildCommand("showVisit");
            var list = new List<Visit>();

            conexion.SqlExecute(() =>
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(MapRequest(ref reader));
            });

            return list.ToArray();
        }

        public Visit GetOne(int id)
        {
            var cmd = conexion.BuildCommand("showVisitbyID");
            cmd.Parameters.AddWithValue("@id", id);
            Visit visit = null;

            conexion.SqlExecute(() =>
            {
                var reader = cmd.ExecuteReader();
                if (reader.Read()) visit = MapRequest(ref reader);
            });

            return visit;
        }
    }
}
