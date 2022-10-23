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

            conexion.SqlExecute(() =>
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read()) results.Add(true);
            });

            foreach (var result in results) Console.WriteLine(result);
            Assert.AreNotEqual(results.Count, 0);
        }

    }
}
