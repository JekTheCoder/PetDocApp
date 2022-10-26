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
    public partial class BuscarCitas : Form
    {

        VisitaNegocio visita = new VisitaNegocio();

        public BuscarCitas()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BuscarCitas_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = visita.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(textBox1.Text, out int idMascota)) return;

            var mascota = visita.GetOne(idMascota);
            if (mascota == null) return;

            Modelos.Visit[] data = { mascota };

            dataGridView2.DataSource = data;
            dataGridView2.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form formulario = new Form1();
            formulario.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
