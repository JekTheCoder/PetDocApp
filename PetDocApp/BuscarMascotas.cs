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
        MascotaExcelExporter mascotaExcelExporter = new MascotaExcelExporter();

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.form1.Show();
            //Form formulario = new Form1();
            //formulario.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            worksheet = workbook.Sheets["hoja1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "CustomerDetail";


            for (int i=1;i< dataGridMascotas.Columns.Count + 1; i++)
            {
                worksheet.Cells[i, 1] = dataGridMascotas.Columns[i - 1].HeaderText;
            }
            for(int i = 0;i<dataGridMascotas.Rows.Count;i++)
            {
                for(int j = 0; j < dataGridMascotas.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2,j + 1] = dataGridMascotas.Rows[i].Cells[j].Value.ToString();
                }
            }
            var saveFile = new SaveFileDialog();
            saveFile.FileName = "output";
            saveFile.DefaultExt = ".xlsx";
            if (saveFile.ShowDialog()==DialogResult.OK)
            {
                workbook.SaveAs(saveFile.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            }
            app.Quit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void BuscarMascotas_Load(object sender, EventArgs e)
        {

        }
    }
}
