﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            if (config.Pembeli.ContainsKey(buyername)){
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
}