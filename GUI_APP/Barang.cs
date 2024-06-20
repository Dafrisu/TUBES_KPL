using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_APP
{
    internal class Barang
    {
        public string Nama {  get; set; }
        public int Stok {  get; set; }
        public int Harga { get; set; }
        public string Kategori { get; set; }

        public Barang(string nama, int stok, int harga, string kategori)
        {
            Nama = nama;
            Stok = stok;
            Harga = harga;
            Kategori = kategori;
        }
    }
}
