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

        public bool Update(Mascota mascota)
        {
            return repository.Update(mascota);
        }

        public bool Create(Mascota mascota)
        {
            return repository.Create(mascota);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
