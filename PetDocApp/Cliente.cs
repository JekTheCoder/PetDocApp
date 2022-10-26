using CapaNegocios;
using Modelos;
using System;
using System.Windows.Forms;

namespace PetDocApp
{
    public partial class Cliente : Form
    {
        private ClienteNegocio repo = new ClienteNegocio();

        public Cliente()
        {
            InitializeComponent();
        }

        public Cliente(Modelos.Cliente client)
        {
            InitializeComponent();
            SetData(client);
        }

        public void SetData(Modelos.Cliente client)
        {
            txtID.Text = client.idCliente.ToString();
            txtName.Text = client.nombreCliente;
            txtLastName.Text = client.apellidoCliente;
            txtCity.Text = client.ciudad;
            txtAddres.Text = client.direccion;
            txtPhone.Text = client.telefono;
        }

        private Modelos.Cliente BuildCliente()
        {
            var cliente = new Modelos.Cliente();
            cliente.idCliente = -1;

            if (int.TryParse(txtID.Text, out int id)) cliente.idCliente = id;
            cliente.nombreCliente = txtName.Text;
            cliente.apellidoCliente = txtLastName.Text;
            cliente.ciudad = txtCity.Text;
            cliente.direccion = txtAddres.Text;
            cliente.telefono = txtPhone.Text;

            return cliente;
        }

        //HORA DEL FORMULARIO
        private void fechahora_Tick(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            repo.Create(BuildCliente());
        }

        private void lblfecha_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            repo.Update(BuildCliente());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id)) return;

            if (!repo.Delete(id)) lblError.Text = "No se pudo eliminar";
        }
    }
}
