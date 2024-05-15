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

        public bool searchKeranjang(UMKM[] toko)
        {
            Console.WriteLine("Masukan nama barang: ");
            String input = Console.ReadLine();
            bool search = false;
            try
            {
                for (int i = 0; i < toko.Length && search == false; i++) // Iterate through all UMKM entries
                {
                    foreach (var kategoriBarang in toko[i].InsertBarang.Keys) // Iterate through categories
                    {
                        var barangDictionary = toko[i].InsertBarang[kategoriBarang]; // Get the dictionary for this category

                        if (barangDictionary.ContainsKey(input)) // Check if item name exists in this category's dictionary
                        {
                            search = true;
                            Console.WriteLine("Barang '" + input + "' ditemukan di UMKM " + toko[i].nama /* property to identify UMKM */); // Informative 
                        }
                    }
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Input Invalid");
            }
            return search;
        }

        public void check(UMKM[] tit, string nama)
        {
            try
            {
                if (searchKeranjang(tit))
                {
                    for (int i = 0; i < tit.Length; i++)
                    {

                        if (tit != null)
                        {
                            if (tit[i].nama == nama)
                            {
                                tit[i].GetBarang();
                                tit[i].KurangStock();
                                tit[i].GetBarang();
                            }
                            else if (i == tit.Length)
                            {
                                throw new Exception("Toko ini tidak menjual " + nama);
                            }
                        }
                        Console.WriteLine("Barang tidak ada");
                    }
                }
                else
                {
                    Console.WriteLine("Barang tidak ada");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
