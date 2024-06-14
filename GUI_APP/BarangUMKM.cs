using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_APP
{
    internal class BarangUMKM
    {
        public String NamaUMKM;
        public string namabarang;
        public int stok;
        public int harga;
        public string kategoriBarang;
        public List<BarangUMKM> listBarang = new List<BarangUMKM>();

        public BarangUMKM(String nama)
        { 
            this.NamaUMKM = nama;
        }
        public BarangUMKM(string namabarang, int stok, int harga, string kategoriBarang)
        {
            this.namabarang = namabarang;
            this.stok = stok;
            this.harga = harga;
            this.kategoriBarang = kategoriBarang;
        }

        public void GenerateBarang1()
        {
            //List Barang Misc
            listBarang.Add(new BarangUMKM("Buku", 10, 10000,"Misc"));
            listBarang.Add(new BarangUMKM("Pensil", 15, 5000, "Misc"));
            listBarang.Add(new BarangUMKM("Pulpen", 20, 3000, "Misc"));
            listBarang.Add(new BarangUMKM("Kertas", 8, 15000, "Misc"));
            listBarang.Add(new BarangUMKM("Spidol", 12, 8000, "Misc"));
            listBarang.Add(new BarangUMKM("Stapler", 5, 20000, "Misc"));
            listBarang.Add(new BarangUMKM("Penghapus", 18, 4000, "Misc"));
            listBarang.Add(new BarangUMKM("Penggaris", 10, 7000, "Misc"));

            //List Barang Makanan
            listBarang.Add(new BarangUMKM("Makaroni", 5, 20000, "Makanan"));
            listBarang.Add(new BarangUMKM("Pizza", 18, 4000, "Makanan"));
            listBarang.Add(new BarangUMKM("Mie Baek", 10, 7000, "Makanan"));

            //List Barang Minuman
            listBarang.Add(new BarangUMKM("Golda", 5, 20000, "Minuman"));
            listBarang.Add(new BarangUMKM("Nipis Madu", 18, 4000, "Minuman"));
            listBarang.Add(new BarangUMKM("Tel-u Water", 10, 7000, "Minuman"));
        }

        public void GenerateBarang2()
        {
            // List Barang Misc
            listBarang.Add(new BarangUMKM("Notebook", 10, 15000, "Misc"));
            listBarang.Add(new BarangUMKM("Marker", 20, 5000, "Misc"));
            listBarang.Add(new BarangUMKM("Whiteboard Eraser", 15, 2500, "Misc"));
            listBarang.Add(new BarangUMKM("Sticky Notes", 30, 3000, "Misc"));
            listBarang.Add(new BarangUMKM("Binder Clips", 50, 1000, "Misc"));
            listBarang.Add(new BarangUMKM("Paper Clips", 100, 500, "Misc"));
            listBarang.Add(new BarangUMKM("Scissors", 10, 12000, "Misc"));
            listBarang.Add(new BarangUMKM("Tape", 25, 8000, "Misc"));

            // List Barang Makanan
            listBarang.Add(new BarangUMKM("Chips", 20, 10000, "Makanan"));
            listBarang.Add(new BarangUMKM("Chocolate Bar", 50, 5000, "Makanan"));
            listBarang.Add(new BarangUMKM("Cookies", 30, 15000, "Makanan"));
            listBarang.Add(new BarangUMKM("Instant Noodles", 40, 3000, "Makanan"));
            listBarang.Add(new BarangUMKM("Granola Bar", 25, 8000, "Makanan"));

            // List Barang Minuman
            listBarang.Add(new BarangUMKM("Coke", 30, 7000, "Minuman"));
            listBarang.Add(new BarangUMKM("Pepsi", 25, 6500, "Minuman"));
            listBarang.Add(new BarangUMKM("Green Tea", 20, 8000, "Minuman"));
            listBarang.Add(new BarangUMKM("Coffee", 50, 5000, "Minuman"));
            listBarang.Add(new BarangUMKM("Juice", 40, 10000, "Minuman"));
        }

        public void TambahBarang(string namaBarang, int stok, int harga, string kategoriBarang) {
            int i = 0 ;
            while (i <= listBarang.Count) {
                if (!namaBarang.Equals(listBarang[i].namabarang))
                {
                    i++;
                }
                else 
                {
                    EditBarang(namaBarang, stok, harga, kategoriBarang);
                }
            }

            if (!listBarang[i].namabarang.Equals(namaBarang)) {
                listBarang.Add(new BarangUMKM(namaBarang, stok, harga, kategoriBarang));
            }
        }

        public void EditBarang(string namaBarang, int stok, int harga, string kategoriBarang) {
            for (int i = 0; i <= listBarang.Count; i++)
            {
                if (namaBarang.Equals(listBarang[i].namabarang))
                {
                    listBarang[i].stok = stok;
                    listBarang[i].harga = harga;
                    listBarang[i].kategoriBarang = kategoriBarang;
                }
            }
        }

        public void deleteBarang(string namaBarang) 
        { 
            foreach (var item in listBarang)
            {
                if (item.namabarang.Equals(namaBarang)) { 
                    listBarang.Remove(item);
                }
            }
        }
    }
}
