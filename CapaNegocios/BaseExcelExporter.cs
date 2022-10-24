using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public abstract class BaseExcelExporter<T> : IExcelExporter<T> where T : class
    {
        private ExcelExporter exporter = new ExcelExporter();

        public void Export(IEnumerable<T> list, string path)
        {
            var table = BuildTable();
            
            foreach(T item in list)
            {
                var row = table.NewRow();
                BindRow(ref row, item);

                table.Rows.Add(row);
            }

            exporter.Export(table, path);
        }

        protected abstract DataTable BuildTable();

        protected abstract void BindRow(ref DataRow dataRow, T item);
    }
}
