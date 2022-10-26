using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetDocApp
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        ///         public static Form1 form1;
        ///         
        public static Form1 form1;
        public static BuscarCitas buscarCitas;
        public static BuscarClientes buscarClientes;
        public static BuscarMascotas buscarMascotas;
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form1 = new Form1());
        }
    }
}
