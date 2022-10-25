using Modelos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class VisitaExcelRepoter : BaseExcelExporter<Visit>
    {
        protected override void BindRow(ref DataRow dataRow, Visit item)
        {
            dataRow["idVisita"] = item.idVisita;
            dataRow["idMascota"] = item.idMascota;
            dataRow["idDoctor"] = item.idDoctor;
            dataRow["Nombre Doctor"] = item.nombreDoctor;
            dataRow["Fecha Visita"] = item.fechaVisita;
            dataRow["Tipo Visita"] = item.tipoVisita;
            dataRow["Observaciones"] = item.observaciones;
        }

        protected override DataTable BuildTable()
        {
            var table = new DataTable();
            table.Columns.Add("idVisita", typeof(int));
            table.Columns.Add("idMascota", typeof(int));
            table.Columns.Add("idDoctor", typeof(int));
            table.Columns.Add("Nombre Doctor", typeof(string));
            table.Columns.Add("Fecha Visita", typeof(DateTime));
            table.Columns.Add("Tipo Visita", typeof(string));
            table.Columns.Add("Observaciones", typeof(string));

            return table;
        }
    }
}
