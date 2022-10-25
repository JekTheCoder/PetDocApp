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
   
    public partial class BuscarMascotas : Form
    {
        MascotaNegocio mascotaNegocio = new MascotaNegocio();
        
        public BuscarMascotas()
        {
            InitializeComponent();

            dataGridMascotas.DataSource = mascotaNegocio.GetAll();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int idMascota)) return;

            var mascota = mascotaNegocio.GetOne(idMascota);
            if (mascota == null) return;

            Modelos.Mascota[] data = { mascota };

            dataGridMascotas.DataSource = data;
            dataGridMascotas.Update();
        }
    }
}
