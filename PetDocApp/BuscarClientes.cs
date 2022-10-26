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
        Cliente cliente = new Cliente();
        Mascota mascota = new Mascota();
        ClienteNegocio clienteNegocio = new ClienteNegocio();

        public BuscarClientes()
        {
            InitializeComponent();
            dataGridClientes.DataSource = clienteNegocio.GetAll();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int idCliente)) return;

            var cliente = clienteNegocio.GetOne(idCliente);
            if (cliente == null) return;

            Modelos.Cliente[] data = { cliente };

            dataGridClientes.DataSource = data;
            dataGridClientes.Update();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Form formulario = new BuscarMascotas();
            formulario.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form formulario = new Form1();
            formulario.Show();
        }
    }
}
