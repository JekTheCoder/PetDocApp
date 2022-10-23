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
                idDoctor = reader.GetInt32(2),
                fechaVisita = reader.GetDateTime(3),
                tipoVisita = reader.GetString(4),
                detalles = reader.GetInt32(5),
                precioBruto = reader.GetDecimal(6),
                IGV = reader.GetDecimal(6),
                preciototal = reader.GetDecimal(7)
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
