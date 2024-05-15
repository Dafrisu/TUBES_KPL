using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keranjang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keranjang.Tests
{
    [TestClass()]
    public class KeranjangPembeliTests
    {
        Dictionary<String, int> keranjang = new Dictionary<String, int>();
        KeranjangPembeli k = new KeranjangPembeli();
        
        [TestMethod()]
        public void KeranjangIsNullTest()
        {
            if (k.KeranjangIsNull(keranjang) == false)
            {
                Assert.Fail();
            }
        }
        [TestMethod()]
        public void SearchKeranjangTest()
        {
            keranjang.Add("Pepsi", 10);
            if (k.SearchKeranjang(keranjang, "Pepsi"))
            {
                Assert.Fail();
            }
        }
        [TestMethod()]
        public void EditKeranjangTest()
        {
            keranjang.Add("Pepsi", 10);
            String nama_barang = "Pepsi";
            int kurang = 5;
            int result;

            k.EditKeranjang(keranjang, nama_barang, kurang);
            keranjang.TryGetValue("Pepsi", out result);

            Assert.AreEqual(5, result);
        }
    }
}