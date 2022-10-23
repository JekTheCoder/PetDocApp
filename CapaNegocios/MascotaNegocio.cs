using CapaDatos;
using Modelos;

namespace CapaNegocios
{
    public class MascotaNegocio
    {
        private Repository<Mascota> repository = new MascotaRepository();

        public Mascota GetOne(int id)
        {
            return repository.GetOne(id);
        }

        public Mascota[] GetAll()
        {
            return repository.GetAll();
        }
    }
}
