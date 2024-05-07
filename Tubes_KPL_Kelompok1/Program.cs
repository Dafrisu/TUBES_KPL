
﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Tubes_KPL_Kelompok1;
using static Tubes_KPL_Kelompok1.UMKM;
using static Tubes_KPL_Kelompok1.IdentifyUser;

class program
{
    static void Main(string[] args)
    {
        String stringCek;
        int intCek = 0;
        IdentifyUser cek = new IdentifyUser();
        stringCek = Console.ReadLine();
        bool umkmInstanceExists = false;
        UMKM b = new UMKM("Warteg Bang kal");

        while (intCek != 5)
        {
            if (stringCek.Equals("Pembeli"))
            {
                cek.Pembeli();
                Pembeli a = new Pembeli();
                Console.WriteLine("Fitur Untuk Pembeli ");
                Console.WriteLine("1. Tambah Banyak barang yang dipesan ");
                Console.WriteLine("2. Print Keranjang");
                Console.WriteLine("3. Login sebagai User yang lain");
                Console.WriteLine("4. Search barang");
                Console.WriteLine("5. Keluar dari program");
                intCek = Convert.ToInt32(Console.ReadLine());
                if (intCek == 1)
                {
                    a.tambahqty();
                }
                else if (intCek == 2)
                {
                    a.Printkeranjang();
                }
                else if (intCek == 3)
                {
                    Console.WriteLine("Masukkan input berupa Pembeli atau UMKM");
                    stringCek = Console.ReadLine();
                } else if (intCek == 4)
                {
                    a.searchKeranjang();
                }

            }
            else if (stringCek.Equals("UMKM"))
            {
                cek.UMKM();
                if (!umkmInstanceExists) // Memeriksa apakah instance UMKM sudah ada
                {
                    Console.WriteLine("Masukkan nama UMKM");
                    string namaUMKM = Console.ReadLine();
                    b = new UMKM(namaUMKM);
                    umkmInstanceExists = true; // Setel menjadi true karena instance UMKM sudah dibuat
                }


                Console.WriteLine("Fitur Untuk UMKM ");
                Console.WriteLine("1. Tambah Stok Barang: ");
                Console.WriteLine("2. Print Barang UMKM");
                Console.WriteLine("3. Ganti Tipe User");
                Console.WriteLine("4. Keluar dari program");
                intCek = Convert.ToInt32(Console.ReadLine());
                if (intCek == 1)
                {
                    b.TambahStockBarang();
                }
                else if (intCek == 2)
                {
                    b.GetBarang();
                }
                else if (intCek == 3)
                {
                    Console.WriteLine("Masukkan input berupa Pembeli atau UMKM");
                    stringCek = Console.ReadLine();
                }
            }
        }
    }
}