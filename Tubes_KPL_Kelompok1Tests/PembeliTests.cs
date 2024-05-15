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
        
        [TestMethod()]
        public void TambahBarangTest()
        {

        }
    }
}