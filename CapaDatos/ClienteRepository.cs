using Modelos;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ClienteRepository : BaseRepository<Cliente>, Repository<Cliente>
    {
        public bool Create(Cliente entity)
        {
            return BuildCreate("insertClient", ref entity);
        }

        public bool Delete(int id)
        {
            return BuildDelete("deleteClient", id);
        }

        public Cliente[] GetAll()
        {
            return BuildGetAll("showClient");
        }

        public Cliente GetOne(int id)
        {
            return BuildGetOne("showClientbyID", id);
        }

        public bool Update(Cliente entity)
        {
            return BuildUpdate("updateClient", ref entity);
        }

        protected override void MapRequest(ref SqlCommand cmd, ref Cliente entity)
        {
            cmd.Parameters.AddWithValue("@id", entity.idCliente);
            cmd.Parameters.AddWithValue("@name", entity.nombreCliente);
            cmd.Parameters.AddWithValue("@lastName", entity.apellidoCliente);
            cmd.Parameters.AddWithValue("@address", entity.direccion);
            cmd.Parameters.AddWithValue("@city", entity.ciudad);
            cmd.Parameters.AddWithValue("@phone", entity.telefono);
        }

        protected override Cliente MapResponse(ref SqlDataReader reader)
        {
            return new Cliente
            {
                idCliente = reader.GetInt32(0),
                nombreCliente = reader.GetString(1),
                apellidoCliente = reader.GetString(2),
                direccion = reader.GetString(3),
                ciudad = reader.GetString(4),
                telefono = reader.GetString(5),
            };
        }
    }
}
