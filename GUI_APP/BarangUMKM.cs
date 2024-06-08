using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_APP
{
    internal class BarangUMKM
    {
        public String namabarang;
        public int stok;
        public int harga;
        public static List<BarangUMKM> listBarang = new List<BarangUMKM>();

        public BarangUMKM(string namabarang, int stok, int harga)
        {
            this.namabarang = namabarang;
            this.stok = stok;
            this.harga = harga;
        }

        public static void GenerateBarang()
        {
            listBarang.Add(new BarangUMKM("Buku", 10, 10000));
            listBarang.Add(new BarangUMKM("Pensil", 15, 5000));
            listBarang.Add(new BarangUMKM("Pulpen", 20, 3000));
            listBarang.Add(new BarangUMKM("Kertas", 8, 15000));
            listBarang.Add(new BarangUMKM("Spidol", 12, 8000));
            listBarang.Add(new BarangUMKM("Stapler", 5, 20000));
            listBarang.Add(new BarangUMKM("Penghapus", 18, 4000));
            listBarang.Add(new BarangUMKM("Penggaris", 10, 7000));
        }
    }
}
