using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_APP
{
    internal class DataKeranjang
    {
        public String namabarang;
        public int qty;
        public int harga;
        public static int total;
        public static List<DataKeranjang> listKeranjang = new List<DataKeranjang>();

        public DataKeranjang()
        {
            
        }

        public DataKeranjang(string namabarang, int harga)
        {
            this.namabarang = namabarang;
            this.harga = harga;
            this.qty = 1;
        }

        public static void tambahkeKeranjang(String namabarang, int harga)
        {
            Boolean found = false;
            foreach(var barang in listKeranjang)
            {
                if (barang.namabarang.Equals(namabarang))
                {
                    found = true;
                    barang.qty++;
                }
            }
            if (!found)
            {
                listKeranjang.Add(new DataKeranjang(namabarang, harga));
            }
        }
    }
}
