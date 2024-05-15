using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tubes_KPL_Kelompok1.UMKM;



namespace Tubes_KPL_Kelompok1
{
    public class Pembeli
    {
        public string nama;
        public Pembeli(String nama) 
        {
            this.nama = nama;
        }
        public static Dictionary<String, int> keranjang = new Dictionary<String, int>();

        public void Printkeranjang()
        {

            foreach (KeyValuePair<string, int> barang in keranjang)
            {
                Console.WriteLine(barang.Key + "\t\t" + barang.Value);
            }
        }

        public void tambahBarang(UMKM umkm)
        {
            Dictionary<String, int> data;
            Console.WriteLine("Masukkan kategori barang (Makanan, Minuman, Misc):");
            string kategoriString = Console.ReadLine();

            Console.WriteLine("Masukan Nama Barang: ");
            String namabarang = Console.ReadLine();

            Console.WriteLine("Masukan Jumlah Barang: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            UMKM.KategoriBarang kategori;
            if (!Enum.TryParse(kategoriString, out kategori))
            {
                Console.WriteLine("Kategori barang tidak valid.");
                return;
            }

            if(!keranjang.ContainsKey(namabarang))
            {
                // Jika barang belum ada dalam keranjang, tambahkan ke keranjang
                keranjang.Add(namabarang, qty);
                
            }
            else
            {
                // Jika barang tidak tersedia, tampilkan pesan kesalahan
                Console.WriteLine($"Barang {namabarang} tidak tersedia dalam kategori {kategori}");
            }
        }

        public void searchKeranjang()
        {
            
            Console.WriteLine("Masukan nama barang: ");
            String input = Console.ReadLine();
            bool search = false;

            try
            {
                foreach (var pair in keranjang)
                {
                    if (keranjang.ContainsKey(input))
                    {
                        search = true;

                    }
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Input Invalid");
            }
            finally
            {
                if (search)
                {
                    Console.WriteLine("Barang ditemukan");
                    foreach (KeyValuePair<string, int> barang in keranjang)
                    {
                        if (barang.Key == input)
                        {
                            Console.WriteLine(barang.Key + "\t\t" + barang.Value);
                        }
                    }
                    //Console.WriteLine(input.Key + "\t\t" + input.Value);
                }
                else
                {
                    Console.WriteLine("Barang tidak ditemukan");
                }
            }
        }
    }
}
