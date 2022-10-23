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
        public int detalles { get; set; }
        public decimal precioBruto { get; set; }
        public decimal IGV { get; set; }
        public decimal preciototal { get; set; }
    }
}
