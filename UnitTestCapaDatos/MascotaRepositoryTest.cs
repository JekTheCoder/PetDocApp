using CapaDatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCapaDatos
{
    [TestClass]
    public class MascotaRepositoryTest
    {
        MascotaRepository repo;

        [TestInitialize]
        public void BeforeEach()
        {
            repo = new MascotaRepository();
        }

        [TestMethod]
        public void GetsAllMascotas()
        {
            var list = repo.GetAll();

            foreach(var item in list)
                Console.WriteLine(string.Concat(item.idMascota.ToString(), " ", item.observaciones));

            Assert.AreNotEqual(list.Length, 0);
        }

        [TestMethod]
        public void GetOneMascota()
        {
            Assert.IsNotNull(repo.GetOne(0));
        }
    }
}
