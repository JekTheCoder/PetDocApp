using Modelos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class MedicationExcelExporter : BaseExcelExporter<Medication>
    {
        protected override void BindRow(ref DataRow dataRow, Medication item)
        {
            dataRow["idVisita"] = item.idVisita;
            dataRow["Observaciones"] = item.observaciones;
            dataRow["idMedicamento"] = item.idMedicamento;
            dataRow["Nombre Medicamento"] = item.nombreMedicamento;
            dataRow[4] = item.precioMedicamento;
            dataRow[5] = item.tipoVisita;
            dataRow[6] = item.dosis;
        }

        protected override DataTable BuildTable()
        {
            var table = new DataTable();
            table.Columns.Add("idVisita", typeof(int));
            table.Columns.Add("Observaciones", typeof(string));
            table.Columns.Add("idMedicamento", typeof(int));
            table.Columns.Add("Nombre Medicamento", typeof(string));
            table.Columns.Add("Precio Medicamento", typeof(string));
            table.Columns.Add("Tipo Visita", typeof(int));
            table.Columns.Add("Dosis", typeof(string));

            return table;
        }
    }
}
