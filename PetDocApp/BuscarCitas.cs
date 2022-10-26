using CapaNegocios;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetDocApp
{
    public partial class BuscarCitas : Form
    {
        private VisitaNegocio repo = new VisitaNegocio();
        private FileExporter<Visit> exporter = new FileExporter<Visit>(new VisitaExcelRepoter());
        private Visit[] visitas;

        public BuscarCitas()
        {
            InitializeComponent();
            GetAllCitas();
        }

        private void GetAllCitas()
        {
            visitas = repo.GetAll();
            dataGridViewCitas.DataSource = visitas;
            dataGridViewCitas.Update();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BuscarCitas_Load(object sender, EventArgs e)
        {

        }

        private void BtnExportClick(object sender, EventArgs e)
        {
            Visit[] data = (Visit[])dataGridViewCitas.DataSource;
            exporter.Export(data);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            GetAllCitas();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearch.Text, out int idMascota)) return;

            var result = visitas.Where(visita => visita.idMascota == idMascota);

            var arr = result.ToArray();

            dataGridViewCitas.DataSource = arr;
            dataGridViewCitas.Update();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            IEnumerable<Visit> data = (IEnumerable<Visit>)dataGridViewCitas.DataSource;
            exporter.Export(data);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
