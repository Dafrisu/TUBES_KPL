using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_KPL_Kelompok1
{
    public class Admin
    {
        public String nama; 
        public Admin(String nama)
        {
            this.nama = nama;
        }

        public void addUMKM(UMKM umkm)
        {
            Console.WriteLine("Masukkan nama UMKM:");
            string namaUMKM = Console.ReadLine();
            umkm.nama = namaUMKM;
        }

        public void deleteUMKM(UMKM umkm)
        {
             //create delete umkm on admin
             Console.WriteLine("Masukkan nama UMKM yang ingin dihapus:");
            string delUMKM = Console.ReadLine();

        }
        public void editUMKM(UMKM umkm)
        {
            Console.WriteLine("Masukkan nama UMKM yang ingin diedit:");
            string namaUMKM = Console.ReadLine();

            if (umkm.nama.Equals(namaUMKM))
            {
                Console.WriteLine("1 untuk ubah nama umkm \n 2 untuk add barang \n 3 untuk hapus barang");
                int i = 0;
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Input tidak valid atau bukan number");
                }
                if (i == 1)
                {
                    Console.WriteLine("Masukkan nama UMKM yang baru:");
                    string newNamaUMKM = Console.ReadLine();
                    umkm.nama = newNamaUMKM;
                }
                else if (i == 2)
                {
                    Console.WriteLine("Masukkan nama barang yang ingin ditambahkan:");
                    string namaBarang = Console.ReadLine();
                    umkm.TambahBarang();
                }
                else if (i == 3)
                {
                    Console.WriteLine("Masukkan nama barang yang ingin dihapus:");
                    umkm.HapusBarang();
                }   
            }
            else
            {
                Console.WriteLine("UMKM dengan nama tersebut tidak ditemukan.");
            }
        }
        public void lihatUMKM(UMKM umkm)
        {
            Console.WriteLine("Nama UMKM: " + umkm.nama);
            Console.WriteLine("Jenis Produk: ");
            foreach (KeyValuePair<string, string> entry in umkm.JenisProduk)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
            Console.WriteLine("Stock: ");
            foreach (KeyValuePair<string, int> entry in umkm.Stock)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }

        public void lihatPembeli(Pembeli pembeli)
        {
            Console.WriteLine("Nama Pembeli: " + pembeli.nama);
            Console.WriteLine("Keranjang: ");
            pembeli.Printkeranjang();
        }
        public void addPembeli(Pembeli pembeli)
        {
            Console.WriteLine("Masukkan nama Pembeli:");
            string namaPembeli = Console.ReadLine();
            pembeli.nama = namaPembeli;
        }
        public void deletePembeli(Pembeli pembeli)
        {
            // delete pembeli on admin
            
        }
    }
}
