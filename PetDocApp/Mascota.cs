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
            Form formulario = new Cliente();
            formulario.Show();
        }

        private void FechaHora_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }
    }
}
