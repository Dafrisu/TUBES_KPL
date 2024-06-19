using Keranjang;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tubes_KPL_Kelompok1
{
    public class Pembeli
    {
        public String nama;
        KeranjangPembeli lib = new KeranjangPembeli();
        public Pembeli(String nama) 
        {
            this.nama = nama;
        }
        public Dictionary<String, int> keranjang = new Dictionary<String, int>();
        

        public String Printkeranjang()
        {

            if (keranjang.Count == 0)
            {
                Console.WriteLine("Keranjang Masih Kosong");
                return "gagal";
            }
            else
            {
                foreach (KeyValuePair<string, int> barang in keranjang)
                {
                    Console.WriteLine(barang.Key + "\t\t" + barang.Value);
                }
                return "berhasil";
            }
        }

        public void tambahBarang(UMKM umkm)
        {
            Boolean cek = false;
            UMKM.KategoriBarang kategori;
            do
            {
                try
                {
                    if (umkm == null)
                    {
                        cek = true;
                        throw new Exception("UMKM Tidak ada");
                    }
                    Console.WriteLine("Masukkan kategori barang (Makanan, Minuman, Misc):");
                    string kategoriString = Console.ReadLine();

                    if (!Enum.TryParse(kategoriString, out kategori))
                    {
                        Console.WriteLine("Kategori barang tidak valid.");
                        return;
                    }
                    Console.WriteLine("Masukan Nama Barang: ");
                    String namabarang = Console.ReadLine();
                    
                    if (!umkm.InsertBarang[kategori].ContainsKey(namabarang))
                    {
                        throw new Exception("Barang Tidak ada");
                        cek = true;
                        return;
                    }
                    Console.WriteLine("Masukan Jumlah Barang: ");
                    int qty = Convert.ToInt32(Console.ReadLine());
                    if (!keranjang.ContainsKey(namabarang))
                    {
                        int stok = umkm.InsertBarang[kategori][namabarang];
                        if (stok > qty)
                        {
                            // Jika barang belum ada dalam keranjang, tambahkan ke keranjang
                            keranjang.Add(namabarang, qty);
                        }
                        else
                        {
                            Console.WriteLine("Stok Barang Tidak mencukupi");
                        }

                    }
                    else if (keranjang.ContainsKey(namabarang))
                    {
                        // Jika barang tidak tersedia, tampilkan pesan kesalahan
                        //Console.WriteLine($"Barang {namabarang} tidak tersedia dalam kategori {kategori}");
                        int stok = umkm.InsertBarang[kategori][namabarang];
                        if (stok > qty)
                        {
                            // Jika barang sudah ada dalam keranjang, tambahkan jumlah QTY ke keranjang
                            keranjang[namabarang] = keranjang[namabarang] + qty;
                        }
                        else
                        {
                            Console.WriteLine("Stok Barang Tidak mencukupi");
                        }

                    }
                    //tambahBarangJSON(kategoriString,namaBarang,qty);
                    cek = true;
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("Inputan Tidak ada Di Data UMKM");
                    cek = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!cek);
            
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

        public void EditKeranjang()
        {
            try
            {
                Console.WriteLine("Keranjang sekarang: ");
                Printkeranjang();
                Console.WriteLine("Lakukan edit keranjang? (Ya/Tidak)");
                String input = Console.ReadLine() ;

                if (input == "Ya")
                {
                    Console.WriteLine("Masukkan nama barang: ");
                    String nama_barang = Console.ReadLine();

                    Console.WriteLine("Masukkan jumlah barang: ");
                    int kurang = Convert.ToInt32(Console.ReadLine());

                    lib.EditKeranjang(keranjang, nama_barang, kurang);
                } 
                else if (input == "Tidak")
                {
                    return;
                } else
                {
                    throw new Exception("bang jawab 'Ya' atau 'Tidak'");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Keranjang sekarang: ");
                Printkeranjang();
            }
        }
    }
}
