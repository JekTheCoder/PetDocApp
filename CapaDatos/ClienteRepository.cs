using Modelos;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ClienteRepository : BaseRepository<Cliente>, Repository<Cliente>
    {
        public bool Create(Cliente entity)
        {
            return BuildCreate("create_cliente", ref entity);
        }

        public bool Delete(int id)
        {
            return BuildDelete("delete_cliente", id);
        }

        public Cliente[] GetAll()
        {
            return BuildGetAll("get_clientes");
        }

        public Cliente GetOne(int id)
        {
            return BuildGetOne("get_cliente", id);
        }

        public bool Update(Cliente entity)
        {
            return BuildUpdate("update_cliente", ref entity);
        }

        protected override void MapRequest(ref SqlCommand cmd, ref Cliente entity)
        {
            cmd.Parameters.AddWithValue("@id", entity.idCliente);
            cmd.Parameters.AddWithValue("@nombreCliente", entity.nombreCliente);
            cmd.Parameters.AddWithValue("@apellidoCliente", entity.apellidoCliente);
            cmd.Parameters.AddWithValue("@direccion", entity.direccion);
            cmd.Parameters.AddWithValue("@ciudad", entity.ciudad);
            cmd.Parameters.AddWithValue("@telefono", entity.telefono);
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
