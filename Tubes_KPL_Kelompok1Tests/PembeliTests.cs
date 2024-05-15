using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tubes_KPL_Kelompok1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace Tubes_KPL_Kelompok1.Tests
{
    [TestClass()]
    public class PembeliTests
    {
        [TestMethod()]
        public void PrintkeranjangTest()
        {
            Pembeli buyer = new Pembeli("Haikal");

            Assert.AreEqual("gagal", buyer.Printkeranjang());
            UMKM umkm = new UMKM("dafa");
            buyer.keranjang.Add("ad", 10);
            Assert.AreEqual("berhasil", buyer.Printkeranjang());
        }

    }

    [TestClass()]
    public class IdentifyUserTests
    {

        //Testing Dafa
        [TestMethod()]
        public void TestingStateNetral()
        {
            IdentifyUser user = new IdentifyUser();
            Assert.AreEqual(IdentifyUser.UserState.Netral, user.getCurrentState());
        }
        [TestMethod()]
        public void TestingStateUMKM()
        {
            IdentifyUser user1 = new IdentifyUser();
            user1.UMKM();
            Assert.AreEqual(IdentifyUser.UserState.UMKM, user1.getCurrentState());
        }
        [TestMethod()]
        public void TestingStatePembeli()
        {
            IdentifyUser user2 = new IdentifyUser();
            user2.Pembeli();
            Assert.AreEqual(IdentifyUser.UserState.Pembeli, user2.getCurrentState());
        }
    }

    [TestClass()]
    public class SomeUMKMTests
    {

        //Testing Dafa
        [TestMethod()]
        public void TestingGetBarang()
        {
            UMKM umkm = new UMKM("dafa");
            Assert.AreEqual("Gagal", umkm.GetBarang());
        }
    }

    [TestClass()]
    public class UMKMUnitTest
    {
        [TestMethod()]
        public static void TestSaveData()
        {
            UMKM umkm = new UMKM("TestUMKM");
            umkm.Stock.Add("TestProduct", 10);
            umkm.JenisProduk.Add("TestProduct", "TestCategory");

            umkm.SaveData();

            // Check if the JSON file exists and contains the expected data
            string json = File.ReadAllText("umkmconfig.json");
            List<UMKM> umkmList = JsonSerializer.Deserialize<List<UMKM>>(json);
            bool success = false;
            foreach (var item in umkmList)
            {
                if (item.nama == "TestUMKM" && item.Stock.ContainsKey("TestProduct"))
                {
                    success = true;
                    break;
                }
            }

            Console.WriteLine("SaveData test result: " + (success ? "Passed" : "Failed"));
        }
        [TestMethod()]
        public static void TestReadJson()
        {
            try
            {
                string json = File.ReadAllText("umkmconfig.json");
                Console.WriteLine("ReadJson test result: Passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReadJson test result: Failed. Error: " + ex.Message);
            }
        }
        [TestMethod()]
        public static void RunTests()
        {
            TestSaveData();
            TestReadJson();
        }
    }
}