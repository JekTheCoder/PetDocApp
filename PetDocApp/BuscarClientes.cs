using CapaNegocios;
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
    public partial class BuscarClientes : Form
    {
        Cliente cliente = new Cliente();
        Mascota mascota = new Mascota();
        MascotaNegocio mascotaneg = new MascotaNegocio();

        public BuscarClientes()
        {
            InitializeComponent();
            dataGridClientes.DataSource = mascotaneg.GetAll();
        }

        private void ListarDatos()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridClientes.DataSource = mascotaneg.GetAll();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
