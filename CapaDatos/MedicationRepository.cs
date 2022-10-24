using Modelos;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class MedicationRepository : BaseRepository<Medication>, Repository<Medication>
    {
        public bool Create(Medication entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Medication[] GetAll()
        {
            var cmd = sql.BuildCommand("showMedication");
            cmd.Parameters.AddWithValue("@id", 1);

            return BuildGetAll(cmd);
        }

        public Medication GetOne(int id)
        {
            return BuildGetOne("showMedicationbyID", id);   
        }

        public bool Update(Medication entity)
        {
            throw new System.NotImplementedException();
        }

        protected override void MapRequest(ref SqlCommand cmd, ref Medication entity)
        {
            throw new System.NotImplementedException();
        }

        protected override Medication MapResponse(ref SqlDataReader reader)
        {
            return new Medication
            {
                idVisita = reader.GetInt32(0),
                observaciones = reader.GetString(1),
                idMedicamento = reader.GetInt32(2),
                nombreMedicamento = reader.GetString(3),
                precioMedicamento = reader.GetDecimal(4),
                dosis = reader.GetString(5),
                tipoVisita = reader.GetInt32(6)
            };
        }
    }
}
