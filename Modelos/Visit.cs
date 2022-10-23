using System;

namespace Modelos
{
    public class Visit
    {
        public int idVisita { get; set; }
        public int idMascota { get; set; }
        public int idDoctor { get; set; }
        public DateTime fechaVisita { get; set; }
        public string tipoVisita { get; set; }
        public string nombreDoctor { get; set; }
        public string observaciones { get; set; }
    }
}
