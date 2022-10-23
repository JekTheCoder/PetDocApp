using Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class MascotaRepository : Repository<Mascota>
    {
        private static SqlConexion sql = SqlConexion.GetSqlConnection();

        private static Mascota MapResponse(ref SqlDataReader reader)
        {
            return new Mascota
            {
                idMascota = reader.GetInt32(0),
                idDueño = reader.GetInt32(1),
                tipoAnimal = reader.GetInt32(2),
                raza = reader.GetString(3),
                sexo = reader.GetString(4)[0],
                fechaNacimiento = reader.GetDateTime(5),
                observaciones = reader.GetString(6)
            };
        }

        private static void MapRequest(ref SqlCommand cmd, ref Mascota entity)
        {
            cmd.Parameters.AddWithValue("@id", entity.idMascota);
            cmd.Parameters.AddWithValue("@id_dueno", entity.idDueño);
            cmd.Parameters.AddWithValue("@tipo_animal", entity.tipoAnimal);
            cmd.Parameters.AddWithValue("@raza", entity.raza);
            cmd.Parameters.AddWithValue("@sexo", entity.sexo);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", entity.fechaNacimiento);
            cmd.Parameters.AddWithValue("@observaciones", entity.observaciones);
        }

        public bool Create(Mascota entity)
        {
            var cmd = sql.BuildCommand("delete_mascota");
            MapRequest(ref cmd, ref entity);

            return sql.SqlExecute(() => cmd.ExecuteNonQuery());
        }

        public bool Delete(int id)
        {
            var cmd = sql.BuildCommand("delete_mascota");
            cmd.Parameters.AddWithValue("@id", id);

            return sql.SqlExecute(() => cmd.ExecuteNonQuery());
        }

        public Mascota[] GetAll()
        {
            var cmd = sql.BuildCommand("get_mascotas");
            var mascotas = new List<Mascota>();

            sql.SqlExecute(() =>
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read()) mascotas.Add(MapResponse(ref reader));
            });

            return mascotas.ToArray();
        }

        public Mascota GetOne(int id)
        {
            var cmd = sql.BuildCommand("get_mascota");
            cmd.Parameters.AddWithValue("@id", id);

            Mascota mascota = null;

            sql.SqlExecute(() =>
            {
                var reader = cmd.ExecuteReader();
                if (reader.Read()) mascota = MapResponse(ref reader);
            });

            return mascota;
        }

        public bool Update(Mascota entity)
        {
            var cmd = sql.BuildCommand("update_mascota");
            MapRequest(ref cmd, ref entity);

            return sql.SqlExecute(() => cmd.ExecuteNonQuery());
        }
    }
}
