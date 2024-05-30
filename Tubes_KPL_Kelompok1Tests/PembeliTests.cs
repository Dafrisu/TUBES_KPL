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
        public void PrintkeranjangKosongTest()
        {
            Pembeli buyer = new Pembeli("Haikal");

            Assert.AreEqual("gagal", buyer.Printkeranjang());
        }
        [TestMethod()]
        public void PrintkeranjangisiTest()
        {
            Pembeli buyer = new Pembeli("Haikal");
            buyer.keranjang.Add("ad", 10);
            Assert.AreEqual("berhasil", buyer.Printkeranjang());
        }

        [TestMethod()]
        public void tambahBarangJSONTest()
        {
            Boolean expected = false;
            BuyerConfig buyer = new BuyerConfig();
            BuyerConfig.tambahbarangjson("dafa", "Haikal", "Bakso", 3);
            BuyerConfig config = JsonSerializer.Deserialize<BuyerConfig>(BuyerConfig.json);
            String umkmname = "dafa";
            String buyername = "Haikal";
            String namabarang = "Bakso";
            int qty = 3;
            if (config.Pembeli.ContainsKey(buyername))
            {
                var buy = config.Pembeli[buyername];
                if (buy.UMKM.ContainsKey(umkmname))
                {
                    var umkm = buy.UMKM[umkmname];
                    if (umkm.ContainsKey(namabarang))
                    {
                        expected = true;
                    }
                }
            }
            Assert.IsTrue(expected);
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
        public void TestSaveData()
        {
            Console.WriteLine("Starting TestSaveData...");

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

            Console.WriteLine("TestSaveData result: " + (success ? "Passed" : "Failed"));
        }
        [TestMethod()]
        public void TestReadJson()
        {
            Console.WriteLine("Starting TestReadJson...");

            try
            {
                string json = File.ReadAllText("umkmconfig.json");
                Console.WriteLine("TestReadJson result: Passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("TestReadJson result: Failed. Error: " + ex.Message);
            }
        }

        public void RunTests()
        {
            TestSaveData();
            TestReadJson();
        }

        public void Main(string[] args)
        {
            RunTests();
        }

    }
    [TestClass()]
    public class testAppstate
    {
        [TestMethod()]
        public void TestingAppsState()
        {
            stateAplikasi state = new stateAplikasi();
            state.FiturUMKM();
            Assert.AreEqual(stateAplikasi.AppsState.FiturUMKM, state.getCurrentState());
            state.FiturPembeli();
            Assert.AreEqual(stateAplikasi.AppsState.FiturPembeli, state.getCurrentState());
            state.FiturAdmin();
            Assert.AreEqual(stateAplikasi.AppsState.FiturAdmin, state.getCurrentState());
        }
    }
    [TestClass()]
    public class testjumlahproduk
    {
        [TestMethod()]
        public void TestingJumlahProduk()
        {
            UMKM umkm = new UMKM("bakso");
            umkm.Stock.Add("Bakso", 10);
            umkm.Stock.Add("Mie Ayam", 5);
            umkm.Stock.Add("Sate", 15);
            Assert.AreEqual(10, umkm.Stock["Bakso"]);
            Assert.AreEqual(5, umkm.Stock["Mie Ayam"]);
            Assert.AreEqual(15, umkm.Stock["Sate"]);
        }
    }
    [TestClass()]
    public class testUMKM
    {
        [TestMethod()]
        public void TestHapusBarang()
        {
            UMKM umkm = new UMKM("DoNut Surrender");
            umkm.InsertBarang[UMKM.KategoriBarang.Makanan] = new Dictionary<string, int>
            {
                { "Donut Coklat", 10 }
            };
            string input = "Donut Coklat\nMakanan";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);
            umkm.HapusBarang(); 
            Assert.IsFalse(umkm.InsertBarang[UMKM.KategoriBarang.Makanan].ContainsKey("DoNut Coklat"));
        }
    }
}