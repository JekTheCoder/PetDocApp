using Modelos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class MascotaExcelExporter : BaseExcelExporter<Mascota>
    {
        protected override void BindRow(ref DataRow dataRow, Mascota item)
        {
            dataRow["idMascota"] = item.idMascota;
            dataRow["idDueño"] = item.idDueño;
            dataRow["tipoAnimal"] = item.tipoAnimal;
            dataRow["raza"] = item.raza;
            dataRow["sexo"] = item.sexo;
            dataRow["Fecha Nacimiento"] = item.fechaNacimiento;
            dataRow["Observaciones"] = item.observaciones;
        }

        protected override DataTable BuildTable()
        {
            var table = new DataTable();
            table.Columns.Add("idMascota", typeof(int));
            table.Columns.Add("idDueño", typeof(int));
            table.Columns.Add("tipoAnimal", typeof(int));
            table.Columns.Add("raza", typeof(string));
            table.Columns.Add("sexo", typeof(char));
            table.Columns.Add("Fecha Nacimiento", typeof(DateTime));
            table.Columns.Add("Observaciones", typeof(string));

            return table;
        }
    }
}
