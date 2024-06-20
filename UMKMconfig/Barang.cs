using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMKMconfig
{
    internal class Barang
    {
        public string Nama { get; set; }
        public int Stok { get; set; }
        public int Harga { get; set; }
        public string Kategori { get; set; }

        public Barang(string nama, int stok, int harga, string kategori)
        {
            Nama = nama;
            Stok = stok;
            Harga = harga;
            Kategori = kategori;
        }

        public override string ToString()
        {
            return $"Barang(Nama={Nama}, Stok={Stok}, Harga={Harga}, Kategori={Kategori})";
        }
    }
}
