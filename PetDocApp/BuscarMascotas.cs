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
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2EGFL5F;Initial Catalog=Veterinaria;Integrated Security=True");
        public BuscarMascotas()
        {
            InitializeComponent();

            dataGridMascotas.DataSource = mascotaNegocio.GetAll();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            string consulta = "select * from Mascota where idMascota = " + textBox1.Text + "";

            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conn);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridMascotas.DataSource = dt;
            SqlCommand comando = new SqlCommand(consulta, conn);
            SqlDataReader lector;
            lector = comando.ExecuteReader();
            conn.Close();
        }
    }
}
