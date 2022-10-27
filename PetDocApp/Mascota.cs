using CapaNegocios;
using System;
using System.Windows.Forms;

namespace PetDocApp
{
    public partial class Mascota : Form
    {
        private MascotaNegocio repo = new MascotaNegocio();
        Option[] generos = { new Option { name = "HEMBRA", value = 'F' }, new Option { name = "MACHO", value = 'M' } };

        public Mascota()
        {
            InitializeComponent();
            cboGenero.Items.Clear();
            cboGenero.Items.AddRange(generos);
        }

        private Modelos.Mascota BuildMascota()
        {
            var mascota = new Modelos.Mascota();
            mascota.observaciones = txtNombre.Text;

            if (!DateTime.TryParse(txtFecha.Text, out DateTime fecha)) return null;
            mascota.fechaNacimiento = fecha;

            if (!int.TryParse(txtType.Text, out int type)) return null; 

            if (!int.TryParse(txtID.Text, out int id)) return null;
            mascota.idMascota = id;

            if (!int.TryParse(txtIDDueño.Text, out int idDueño)) return null;
            mascota.idDueño = idDueño;

            mascota.raza = txtRaza.Text;

            mascota.sexo = cboGenero.SelectedIndex == 0 ? 'H' : 'M';

            return mascota;
        }

        public void SetData(Modelos.Mascota mascota)
        {
            txtNombre.Text = mascota.observaciones;
            txtFecha.Text = mascota.fechaNacimiento.ToString();
            txtID.Text = mascota.idMascota.ToString();
            txtIDDueño.Text = mascota.idDueño.ToString();
            txtRaza.Text = mascota.raza;
            txtType.Text = mascota.tipoAnimal.ToString();

            var i = mascota.sexo == 'M' ? 1 : 0;
            cboGenero.SelectedIndex = i;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mascota = BuildMascota();
            if (mascota == null)
            {
                lblError.Text = "Rellene el Formulario";
                return;
            }

            if (!repo.Create(mascota)) lblError.Text = "No se pudo crear";
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
            var mascota = BuildMascota();
            if (mascota == null)
            {
                lblError.Text = "Rellene el Formulario";
                return;
            }

            if (!repo.Update(mascota)) lblError.Text = "No se pudo actualizar";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id)) return;

            if (!repo.Delete(id)) lblError.Text = "No se pudo Eliminar";
        }
    }

    internal class Option
    {
        public string name;
        public char value;

        public override string ToString()
        {
            return name;
        }

    }
}
