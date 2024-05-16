using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tubes_KPL_Kelompok1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class UMKMTests
    {
        //Testing fersya
        [TestMethod()]
        public void jumlahprodukTest()
        {
           
            UMKM umkm = new UMKM("DoNut Surrender");
            umkm.TambahBarang(); 
            UMKM[] umkmArray = new UMKM[] { umkm, null };
            int totalProducts = umkm.jumlahproduk();
            Assert.IsTrue(totalProducts == 20);
        }
    }
    [TestClass()]
    public class UMKMTests2
    {
        [TestMethod()]
        public void HapusBarangTest()
        {
            UMKM umkm = new UMKM("Toko Kelontong");

            string namaBarang = "Sabun";
            UMKM.KategoriBarang kategori = UMKM.KategoriBarang.Misc;
            int initialStock = 10;
            umkm.TambahBarang();
            try
            {
                umkm.HapusBarang();
            }
            catch (Exception e)
            {
                
                Assert.Fail($"Unexpected exception: {e.Message}");
            }
            bool itemRemoved = !umkm.InsertBarang.ContainsKey(kategori);
            Assert.IsTrue(itemRemoved, $"barang '{namaBarang}' tidak terhapus dari kategori {kategori}");
        }   
    }
}