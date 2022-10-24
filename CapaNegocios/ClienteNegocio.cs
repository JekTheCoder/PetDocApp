using CapaDatos;
using Modelos;

namespace CapaNegocios
{
    public class ClienteNegocio
    {
        private Repository<Cliente> repo = new ClienteRepository(); 

        public Cliente[] GetAll()
        {
            return repo.GetAll();
        }

        public Cliente GetOne(int id)
        {
            return repo.GetOne(id);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

        public bool Create(Cliente cliente)
        {
            return repo.Create(cliente);
        }

        public bool Update(Cliente cliente)
        {
            return repo.Update(cliente);
        }
    }
}
