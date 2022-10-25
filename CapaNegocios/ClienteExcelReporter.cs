using Modelos;
using System.Data;

namespace CapaNegocios
{
    public class ClienteExcelReporter : BaseExcelExporter<Cliente>
    {
        protected override void BindRow(ref DataRow dataRow, Cliente item)
        {
            dataRow["idCliente"] = item.idCliente;
            dataRow["Nombres"] = item.nombreCliente;
            dataRow["Apellidos"] = item.apellidoCliente;
            dataRow["Direccion"] = item.direccion;
            dataRow["Ciudad"] = item.direccion;
            dataRow["Telefono"] = item.telefono;
        }

        protected override DataTable BuildTable()
        {
            var table = new DataTable();
            table.Columns.Add("idCliente", typeof(int));
            table.Columns.Add("Nombres", typeof(string));
            table.Columns.Add("Apellidos", typeof(string));
            table.Columns.Add("Direccion", typeof(string));
            table.Columns.Add("Ciudad", typeof(string));
            table.Columns.Add("Telefono", typeof(string));

            return table;
        }
    }
}
