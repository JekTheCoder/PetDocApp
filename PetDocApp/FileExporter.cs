using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PetDocApp
{
    internal class FileExporter<T> where T : class
    {
        private IExcelExporter<T> exporter;

        public FileExporter(IExcelExporter<T> exporter)
        {
            this.exporter = exporter;   
        }

        public void Export(IEnumerable<T> data)
        {
            var filename = OpenSaveFileDialog();
            if (filename == null) return;

            var extension = ".xlsx";

            var ext = filename.Substring(filename.Length - extension.Length);
            if (!ext.Equals(extension)) filename = filename + extension;

            try
            {
                exporter.Export(data, filename);
                OpenSuccessDialog();
            }
            catch (Exception ex)
            {
                RaiseErrorDialog(ex.Message);
            }
        }

        private void RaiseErrorDialog(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OpenSuccessDialog()
        {
            MessageBox.Show("Archivo Guardado", "Exportado Exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string OpenSaveFileDialog()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.Filter = "excel files (*.xlsx)|*.xlsx";

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return null;

            return saveFileDialog.FileName;
        }
    } 
}
