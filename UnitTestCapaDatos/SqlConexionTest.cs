using CapaDatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCapaDatos
{
    [TestClass]
    public class SqlConexionTest
    {
        SqlConexion conexion;

        [TestInitialize]
        public void BeforeEach()
        {
            conexion = SqlConexion.GetSqlConnection();
        }

        [TestMethod]
        public void ShouldConnect()
        {
            var cmd = conexion.BuildCommand("showPet");

            var results = new List<bool>();

            cmd.Connection.Open();

            var reader = cmd.ExecuteReader();
            while (reader.Read()) results.Add(true);

            cmd.Connection.Close();

            foreach (var result in results) Console.WriteLine(result);
            Assert.AreNotEqual(results.Count, 0);
        }

    }
}
