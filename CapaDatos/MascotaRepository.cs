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
            cmd.Parameters.AddWithValue("@idOwner", entity.idDueño);
            cmd.Parameters.AddWithValue("@typePet", entity.tipoAnimal);
            cmd.Parameters.AddWithValue("@race", entity.raza);
            cmd.Parameters.AddWithValue("@gender", entity.sexo.ToString());
            cmd.Parameters.AddWithValue("@birthDay", entity.fechaNacimiento);
            cmd.Parameters.AddWithValue("@observations", entity.observaciones);
        }

        public bool Create(Mascota entity)
        {
            return BuildCreate("insertPet", ref entity);
        }

        public bool Delete(int id)
        {
            return BuildDelete("deletePet", id);
        }

        public Mascota[] GetAll()
        {
            return BuildGetAll("showPet");
        }

        public Mascota GetOne(int id)
        {
            return BuildGetOne("showPetbyID", id);
        }

        public bool Update(Mascota entity)
        {
            return BuildUpdate("updatetPet", ref entity);
        }
    }
}
