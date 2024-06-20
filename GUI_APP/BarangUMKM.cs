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
        
        public List<Barang> listBarang = new List<Barang>();

        public BarangUMKM(String nama)
        { 
            this.NamaUMKM = nama;
        }

        public void GenerateBarang1()
        {
            //List Barang Misc
            listBarang.Add(new Barang("Buku", 10, 10000,"Misc"));
            listBarang.Add(new Barang("Pensil", 15, 5000, "Misc"));
            listBarang.Add(new Barang("Pulpen", 20, 3000, "Misc"));
            listBarang.Add(new Barang("Kertas", 8, 15000, "Misc"));
            listBarang.Add(new Barang("Spidol", 12, 8000, "Misc"));
            listBarang.Add(new Barang("Stapler", 5, 20000, "Misc"));
            listBarang.Add(new Barang("Penghapus", 18, 4000, "Misc"));
            listBarang.Add(new Barang("Penggaris", 10, 7000, "Misc"));

            //List Barang Makanan
            listBarang.Add(new Barang("Makaroni", 5, 20000, "Makanan"));
            listBarang.Add(new Barang("Pizza", 18, 4000, "Makanan"));
            listBarang.Add(new Barang("Mie Baek", 10, 7000, "Makanan"));

            //List Barang Minuman
            listBarang.Add(new Barang("Golda", 5, 20000, "Minuman"));
            listBarang.Add(new Barang("Nipis Madu", 18, 4000, "Minuman"));
            listBarang.Add(new Barang("Tel-u Water", 10, 7000, "Minuman"));
        }

        public void GenerateBarang2()
        {
            // List Barang Misc
            listBarang.Add(new Barang("Notebook", 10, 15000, "Misc"));
            listBarang.Add(new Barang("Marker", 20, 5000, "Misc"));
            listBarang.Add(new Barang("Whiteboard Eraser", 15, 2500, "Misc"));
            listBarang.Add(new Barang("Sticky Notes", 30, 3000, "Misc"));
            listBarang.Add(new Barang("Binder Clips", 50, 1000, "Misc"));
            listBarang.Add(new Barang("Paper Clips", 100, 500, "Misc"));
            listBarang.Add(new Barang("Scissors", 10, 12000, "Misc"));
            listBarang.Add(new Barang("Tape", 25, 8000, "Misc"));

            // List Barang Makanan
            listBarang.Add(new Barang("Chips", 20, 10000, "Makanan"));
            listBarang.Add(new Barang("Chocolate Bar", 50, 5000, "Makanan"));
            listBarang.Add(new Barang("Cookies", 30, 15000, "Makanan"));
            listBarang.Add(new Barang("Instant Noodles", 40, 3000, "Makanan"));
            listBarang.Add(new Barang("Granola Bar", 25, 8000, "Makanan"));

            // List Barang Minuman
            listBarang.Add(new Barang("Coke", 30, 7000, "Minuman"));
            listBarang.Add(new Barang("Pepsi", 25, 6500, "Minuman"));
            listBarang.Add(new Barang("Green Tea", 20, 8000, "Minuman"));
            listBarang.Add(new Barang("Coffee", 50, 5000, "Minuman"));
            listBarang.Add(new Barang("Juice", 40, 10000, "Minuman"));
        }

        //Method untuk menambahkan Barang
        public void TambahBarang(string namaBarang, int stok, int harga, string kategoriBarang) {
            Boolean found = false;
            
            //melakukan searching yang akan mengupdate found
            foreach (var barang in listBarang) {
                if (barang.Nama.Equals(namaBarang)) 
                {
                    found = true;
                    EditBarang(namaBarang, stok, harga, kategoriBarang);
                }
            }

            if (!found) {
                listBarang.Add(new Barang(namaBarang, stok, harga, kategoriBarang));
            }
        }

        //Method untuk menambahkan barang kedalam Dictionary barang milik UMKM
        public void EditBarang(string namaBarang, int stok, int harga, string kategoriBarang) {
            bool itemFound = false;

            // Melakukan searching dengan menggunakan Foreach
            foreach (var barang in listBarang)
            {
                if (string.Equals(namaBarang, barang.Nama, StringComparison.OrdinalIgnoreCase))
                {
                    // Debugging output
                    MessageBox.Show($"Found Barang: {barang.Nama}, updating values...");

                    barang.Stok = stok;
                    barang.Harga = harga;
                    barang.Kategori = kategoriBarang;

                    itemFound = true;
                    break;
                }
            }

            if (!itemFound)
            {
                MessageBox.Show($"Barang dengan nama {namaBarang} tidak ditemukan.");
            }
        }

        //Method untuk menghapus barang pada Dictionary barang
        public void deleteBarang(String barang)
        {
            var itemsToRemove = listBarang.Where(b => b.Nama.Equals(barang)).ToList();
            foreach (var item in itemsToRemove)
            {
                listBarang.Remove(item);
            }
        }
    }
}
