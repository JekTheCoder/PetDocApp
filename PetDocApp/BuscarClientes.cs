using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetDocApp
{
    public partial class BuscarClientes : Form
    {
        ClienteNegocio clienteNegocio = new ClienteNegocio();
        private FileExporter<Modelos.Cliente> exporter = new FileExporter<Modelos.Cliente>(new ClienteExcelReporter());

        public BuscarClientes()
        {
            InitializeComponent();
            dataGridClientes.DataSource = clienteNegocio.GetAll();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearch.Text, out int idCliente)) return;

            var cliente = clienteNegocio.GetOne(idCliente);
            if (cliente == null) return;

            Modelos.Cliente[] data = { cliente };

            dataGridClientes.DataSource = data;
            dataGridClientes.Update();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void BtnExportarClick(object sender, EventArgs e)
        {
            Modelos.Cliente[] clientes = (Modelos.Cliente[])dataGridClientes.DataSource;
            exporter.Export(clientes);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            txtSearch.Text = String.Empty;
            dataGridClientes.DataSource = clienteNegocio.GetAll();
            dataGridClientes.Update();
        }
    }
}
