using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetDocApp
{
   
    public partial class BuscarMascotas : Form
    {
        MascotaNegocio mascotaNegocio = new MascotaNegocio();
        FileExporter<Modelos.Mascota> exporter = new FileExporter<Modelos.Mascota>(new MascotaExcelExporter());
        Mascota modal;

        public BuscarMascotas()
        {
            InitializeComponent();

            dataGridMascotas.DataSource = mascotaNegocio.GetAll();

            
        }

        private void ShowMascotaDialog()
        {
            if (modal == null)
            {
                modal = new Mascota();
                modal.Show();
            };

            if (modal.IsDisposed)
            {
                modal = null;
                ShowMascotaDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearch.Text, out int idMascota)) return;

            var mascota = mascotaNegocio.GetOne(idMascota);
            if (mascota == null) return;

            Modelos.Mascota[] data = { mascota };

            dataGridMascotas.DataSource = data;
            dataGridMascotas.Update();
        }

        private void BuscarMascotas_Load(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            var data = (IEnumerable<Modelos.Mascota>)dataGridMascotas.DataSource;
            exporter.Export(data);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridMascotas.DataSource = mascotaNegocio.GetAll();
            dataGridMascotas.Update();
        }

        private void dataGridMascotas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            var data = (Modelos.Mascota[])dataGridMascotas.DataSource;
            Modelos.Mascota cliente;
            try
            {
                cliente = data[i];
            } catch
            {
                return;
            }

            if (cliente == null) return;

            ShowMascotaDialog();
            modal.SetData(cliente);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowMascotaDialog();
        }
    }
}
