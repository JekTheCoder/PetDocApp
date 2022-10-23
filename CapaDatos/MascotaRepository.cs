using Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class MascotaRepository : BaseRepository<Mascota>, Repository<Mascota>
    {
        protected override Mascota MapResponse(ref SqlDataReader reader)
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

        protected override void MapRequest(ref SqlCommand cmd, ref Mascota entity)
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
            return BuildCreate("create_mascota", ref entity);
        }

        public bool Delete(int id)
        {
            return BuildDelete("delete_mascota", id);
        }

        public Mascota[] GetAll()
        {
            return BuildGetAll("get_mascota");
        }

        public Mascota GetOne(int id)
        {
            return BuildGetOne("get_mascota", id);
        }

        public bool Update(Mascota entity)
        {
            return BuildUpdate("update_mascota", ref entity);
        }
    }
}
