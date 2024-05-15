
﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Tubes_KPL_Kelompok1;
using static Tubes_KPL_Kelompok1.Keranjang;
using static Tubes_KPL_Kelompok1.UMKM;
using static Tubes_KPL_Kelompok1.IdentifyUser;

class program
{
    static void Main(string[] args)
    {
        string stringCek;
        int intCek = 0;
        IdentifyUser cek = new IdentifyUser();
        Console.WriteLine("Masukkan input berupa Pembeli atau UMKM");
        stringCek = Console.ReadLine();
        List<UMKM> umkmList = new List<UMKM>();
        int currentUMKMIndex = -1;
        string namaUMKM;

        while (intCek != 11)
        {
            if (stringCek.Equals("Pembeli", StringComparison.OrdinalIgnoreCase))
            {
                cek.Pembeli();
                Pembeli a = new Pembeli("Username");
                Console.WriteLine("Fitur Untuk Pembeli ");
                Console.WriteLine("1. Tambah barang yang dipesan ");
                Console.WriteLine("2. Print Keranjang");
                Console.WriteLine("3. Search barang");
                Console.WriteLine("4. Tambah Barang yang dipesan V2");
                Console.WriteLine("5. Mengurangi jumlah stok UMKM berdasarkan pesanan di keranjang(Order)");
                Console.WriteLine("6. Login sebagai User yang lain");
                Console.WriteLine("10. Keluar dari program");
                intCek = Convert.ToInt32(Console.ReadLine());
                if (intCek == 1)
                {
                    a.tambahBarang(umkmList[currentUMKMIndex]);
                }
                else if (intCek == 2)
                {
                    a.Printkeranjang();
                }
                else if (intCek == 3)
                {
                    a.searchKeranjang();
                }
                else if (intCek == 4)
                {
                    a.tambahBarang(umkmList[currentUMKMIndex]); // Assuming this method exists in Pembeli class
                }
                else if (intCek == 5)
                {
                    //Keranjang.check(arrUMKM,"Dafa");
                }
                else if (intCek == 6)
                {
                    Console.WriteLine("Masukkan input berupa Pembeli atau UMKM");
                    stringCek = Console.ReadLine();
                }
            }
            else if (stringCek.Equals("UMKM", StringComparison.OrdinalIgnoreCase))
            {
                cek.UMKM();

                if (currentUMKMIndex == -1)
                {
                    Console.WriteLine("Masukkan nama UMKM");
                    namaUMKM = Console.ReadLine();
                    UMKM newUMKM = new UMKM(namaUMKM);
                    umkmList.Add(newUMKM);
                    currentUMKMIndex = umkmList.Count - 1;
                }

                Console.WriteLine("Anda login di akun UMKM dengan id :" + currentUMKMIndex);
                Console.WriteLine("Dengan nama :" + umkmList[currentUMKMIndex].Username);

                Console.WriteLine("Fitur Untuk UMKM ");
                Console.WriteLine("1. Tambah Barang: ");
                Console.WriteLine("2. Print Barang UMKM");
                Console.WriteLine("3. Tambah Stok Barang");
                Console.WriteLine("4. Kurang Stok Barang");
                Console.WriteLine("5. Tambah Akun UMKM");
                Console.WriteLine("6. Ganti login akun UMKM (Menggunakan Index)");
                Console.WriteLine("7. Tampilkan Index dan nama sesuai dengan Index");
                Console.WriteLine("8. Print");
                Console.WriteLine("10. Login sebagai User yang lain");
                Console.WriteLine("11. Keluar dari program");
                intCek = Convert.ToInt32(Console.ReadLine());
                if (intCek == 1)
                {
                    umkmList[currentUMKMIndex].TambahBarang();
                }
                else if (intCek == 2)
                {
                    umkmList[currentUMKMIndex].GetBarang();
                }
                else if (intCek == 3)
                {
                    umkmList[currentUMKMIndex].TambahStok();
                }
                else if (intCek == 4)
                {
                    umkmList[currentUMKMIndex].KurangStok();
                }
                else if (intCek == 5)
                {
                    Console.WriteLine("Masukkan nama UMKM");
                    namaUMKM = Console.ReadLine();
                    UMKM newUMKM = new UMKM(namaUMKM);
                    umkmList.Add(newUMKM);
                    currentUMKMIndex = umkmList.Count - 1;
                }
                else if (intCek == 6)
                {
                    Console.WriteLine("Masukkan input berupa Int index yang tersedia");
                    for (int i = 0; i < umkmList.Count; i++)
                    {
                        Console.WriteLine($"{i}. {umkmList[i].Username}");
                    }
                    currentUMKMIndex = Convert.ToInt32(Console.ReadLine());
                }
                else if (intCek == 7)
                {
                    for (int i = 0; i < umkmList.Count; i++)
                    {
                        Console.WriteLine($"{i}. {umkmList[i].Username}");
                    }
                }
                else if (intCek == 8)
                {
                    ReadJson();
                }
                else if (intCek == 9)
                {
                    umkmList[currentUMKMIndex].GetBarang();
                }
                else if (intCek == 10)
                {
                    Console.WriteLine("Masukkan input berupa Pembeli atau UMKM");
                    stringCek = Console.ReadLine();
                }
            }
        }
    }

    private static void ReadJson()
    {
        try
        {
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "umkmconfig.json");
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine("File umkmconfig.json tidak ditemukan.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}