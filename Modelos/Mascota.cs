using System;

namespace Modelos
{
    public class Mascota
    {
        public int idMascota { get; set; }
        public int idDueño { get; set; }
        public int tipoAnimal { get; set; }

        public string raza { get; set; }
        public char sexo { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string observaciones { get; set; }
    }
}
