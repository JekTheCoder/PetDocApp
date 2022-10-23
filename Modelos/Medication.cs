namespace Modelos
{
    public class Medication
    {
        public int idVisita { get; set; }
        public string observaciones { get; set; }
        public int idMedicamento { get; set; }
        public string nombreMedicamento { get; set; }
        public decimal precioMedicamento { get; set; }
        public int tipoVisita { get; set; }
        public string dosis { get; set; }
    }
}
