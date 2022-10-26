using CapaNegocios;
using System;
using System.Windows.Forms;

namespace PetDocApp
{
    public partial class BuscarClientes : Form
    {
        ClienteNegocio clienteNegocio = new ClienteNegocio();
        private FileExporter<Modelos.Cliente> exporter = new FileExporter<Modelos.Cliente>(new ClienteExcelReporter());
        Cliente modal;

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

        private void ShowCliente()
        {
            if (modal == null)
            {
                modal = new Cliente();
                modal.Show();
            };

            if (modal.IsDisposed)
            {
                modal = null;
                ShowCliente();
            }
        }

        private void dataGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            var data = (Modelos.Cliente[])dataGridClientes.DataSource;
            var cliente = data[i];

            if (cliente == null) return;

            ShowCliente();
            modal.SetData(cliente);
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
            txtSearch.Text = string.Empty;
            dataGridClientes.DataSource = clienteNegocio.GetAll();
            dataGridClientes.Update();
        }

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            ShowCliente();
        }
    }
}
