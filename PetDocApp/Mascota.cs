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
    public partial class Mascota : Form
    {
        private MascotaNegocio mascotas = new MascotaNegocio();

        public Mascota()
        {
            InitializeComponent();

            // The view is finnally connected to database! Remove these instructions and make magic ✨
            var list = mascotas.GetAll();
            txtNombre.Text = list[0].observaciones;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void FechaHora_Tick(object sender, EventArgs e)
        {
            
        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
