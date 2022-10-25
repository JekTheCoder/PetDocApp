using CapaDatos;
using Modelos;

namespace CapaNegocios
{
    public class VisitaNegocio
    {
        private VisitRepository repository = new VisitRepository();

        public Visit[] GetAll()
        {
            return repository.GetAll();
        }

        public Visit GetOne(int id)
        {
            return repository.GetOne(id);
        }
    }
}
