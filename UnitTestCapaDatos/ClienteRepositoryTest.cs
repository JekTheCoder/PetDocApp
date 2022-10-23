using CapaDatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCapaDatos
{
    [TestClass]
    public class ClienteRepositoryTest
    {
        ClienteRepository repo;

        [TestInitialize]
        public void BeforeEach()
        {
            repo = new ClienteRepository();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var list = repo.GetAll();

            foreach (var item in list)
                Console.WriteLine(string.Concat(item.idCliente.ToString(), " ", item.nombreCliente));

            Assert.AreNotEqual(list.Length, 0);
        }
    }
}