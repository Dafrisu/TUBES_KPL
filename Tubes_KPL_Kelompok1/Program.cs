
﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Tubes_KPL_Kelompok1;
using Keranjang;
using static Tubes_KPL_Kelompok1.UMKM;
using static Tubes_KPL_Kelompok1.IdentifyUser;

class program
{
    static void Main(string[] args)
    {
        //Global Variabel
        String stringCek;
        int intCek = 0;
        bool umkmInstanceExists = false;
        bool pembeliInstanceExists = false;
        int indexUMKM = 0;
        int banyakUMKM = 0;
        int banyakPembeli = 0;
        string namaUMKM;
        int loopCounter = 0;
        int indexPembeli = 0;
        String namaPembeli;

        //Pemanggilan Class
        UMKM[] arrUMKM = new UMKM[20];
        BuyerConfig buyer = new BuyerConfig();
        Pembeli[] arrPembeli = new Pembeli[20];

        //Initial run
        IdentifyUser cek = new IdentifyUser();
        stringCek = Console.ReadLine();
        

        while (intCek != 12)
        {
            if (stringCek.Equals("Pembeli"))        
            {
                cek.Pembeli();
                if (!pembeliInstanceExists) // Memeriksa apakah instance UMKM sudah ada
                {
                    Console.WriteLine("Masukkan nama Pembeli");
                    namaPembeli = Console.ReadLine();
                    arrPembeli[indexPembeli] = new Pembeli(namaPembeli);
                    Console.WriteLine("Anda login di akun Pembeli dengan id :" + indexPembeli);
                    Console.WriteLine("Dengan nama :" + arrPembeli[indexPembeli].nama);
                    pembeliInstanceExists = true;
                }
                Console.WriteLine("Fitur Untuk Pembeli ");
                Console.WriteLine("1. Tambah barang yang dipesan ");
                Console.WriteLine("2. Print Keranjang");
                Console.WriteLine("3. Search barang");
                Console.WriteLine("4. Tambah Barang yang dipesan V2");
                Console.WriteLine("5. Mengurangi jumlah stok UMKM berdasarkan pesanan di keranjang(Order)");
                Console.WriteLine("6. Tambah Akun Pembeli");
                Console.WriteLine("7. Ganti login akun Pembeli (Menggunakan Index)");
                Console.WriteLine("8. Tampilkan Index dan nama sesuai dengan Index");
                Console.WriteLine("9. Login sebagai User yang lain");
                Console.WriteLine("12. Keluar dari program");
                intCek = Convert.ToInt32(Console.ReadLine());
                if (intCek == 1)
                {
                    arrPembeli[indexPembeli].tambahBarang(arrUMKM[indexUMKM]);
                }
                else if (intCek == 2)
                {
                    arrPembeli[indexPembeli].Printkeranjang();
                }
                else if (intCek == 3)
                {
                    arrPembeli[indexPembeli].searchKeranjang();
                }
                else if (intCek == 4)
                {
                    
                }
                else if (intCek == 5)
                {
                    //Keranjang.check(arrUMKM,"Dafa");
                    Console.WriteLine("");
                    
                }
                else if (intCek == 6)
                {
                    if (arrPembeli[indexPembeli] != null)
                    {
                        while (arrPembeli[indexPembeli] != null)
                        {
                            indexPembeli++;
                        }
                    }
                    if (arrPembeli[indexPembeli] == null)
                    {
                        banyakPembeli = indexPembeli;
                        Console.WriteLine("Masukkan nama Pembeli");
                        namaPembeli = Console.ReadLine();
                        arrPembeli[indexPembeli] = new Pembeli(namaPembeli);
                        Console.WriteLine("Anda login di akun Pembeli dengan id :" + indexPembeli);
                        Console.WriteLine("Dengan nama :" + arrPembeli[indexPembeli].nama);
                    }
                }
                else if (intCek == 7)
                {
                    Console.WriteLine("Masukkan input berupa Int index yang tersedia");
                    while (loopCounter <= banyakPembeli)
                    {
                        Console.WriteLine("Berikut adalah array index id Pembeli yang sudah disimpan");
                        Console.WriteLine(loopCounter + ". " + arrPembeli[loopCounter].nama);
                        loopCounter++;
                    }
                    loopCounter = 0;

                    indexUMKM = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Anda login di akun UMKM dengan id :" + indexPembeli);
                    Console.WriteLine("Dengan nama :" + arrPembeli[indexPembeli].nama);

                }
                else if (intCek == 8)
                {
                    while (loopCounter <= banyakPembeli)
                    {
                        Console.WriteLine("Berikut adalah array index id UMKM yang sudah disimpan");
                        Console.WriteLine(loopCounter + ". " + arrPembeli[loopCounter].nama);
                        loopCounter++;
                    }
                    loopCounter = 0;
                }

                else if (intCek == 9)
                {
                    Console.WriteLine("Masukkan input berupa Pembeli atau UMKM");
                    stringCek = Console.ReadLine();
                }
            }
            else if (stringCek.Equals("UMKM"))
            {
                cek.UMKM();

                if (!umkmInstanceExists) // Memeriksa apakah instance UMKM sudah ada
                {
                    Console.WriteLine("Masukkan nama UMKM");
                    namaUMKM = Console.ReadLine();
                    arrUMKM[indexUMKM] = new UMKM(namaUMKM);
                    Console.WriteLine("Dengan nama :" + arrUMKM[indexUMKM].nama);
                    umkmInstanceExists = true;
                }
                Console.WriteLine("Anda login di akun UMKM dengan id :" + indexUMKM);
                Console.WriteLine("Fitur Untuk UMKM ");
                Console.WriteLine("1. Tambah Barang: ");
                Console.WriteLine("2. Print Barang UMKM");
                Console.WriteLine("3. Tambah Stok Barang");
                Console.WriteLine("4. Kurang Stok Barang");
                Console.WriteLine("5. Tambah Akun UMKM");
                Console.WriteLine("6. Ganti login akun UMKM (Menggunakan Index)");
                Console.WriteLine("7. Tampilkan Index dan nama sesuai dengan Index");
                Console.WriteLine("8. Hapus Barang");
                Console.WriteLine("9. Nama UMKM dan Jumlah Barang");
                Console.WriteLine("10. Lihat Log");
                Console.WriteLine("11. Ganti Tipe User");
                Console.WriteLine("12. Keluar dari program");
                intCek = Convert.ToInt32(Console.ReadLine());
                if (intCek == 1)
                {
                    arrUMKM[indexUMKM].TambahBarang();
                }
                else if (intCek == 2)
                {
                    arrUMKM[indexUMKM].GetBarang();
                }
                else if (intCek == 3)
                {
                    arrUMKM[indexUMKM].TambahStock();
                }
                else if (intCek == 4)
                {
                    arrUMKM[indexUMKM].KurangStock();
                }
                else if (intCek == 5)
                {
                    if (arrUMKM[indexUMKM] != null)
                    {
                        while (arrUMKM[indexUMKM] != null)
                        {
                            indexUMKM++;
                        }
                    }
                    if (arrUMKM[indexUMKM] == null)
                    {
                        banyakUMKM = indexUMKM;
                        Console.WriteLine("Masukkan nama UMKM");
                        namaUMKM = Console.ReadLine();
                        arrUMKM[indexUMKM] = new UMKM(namaUMKM);
                        Console.WriteLine("Anda login di akun UMKM dengan id :" + indexUMKM);
                        Console.WriteLine("Dengan nama :" + arrUMKM[indexUMKM].nama);
                    }
                }
                else if (intCek == 6)
                {
                    Console.WriteLine("Masukkan input berupa Int index yang tersedia");
                    while (loopCounter <= banyakUMKM)
                    {
                        Console.WriteLine("Berikut adalah array index id UMKM yang sudah disimpan");
                        Console.WriteLine(loopCounter + ". " + arrUMKM[loopCounter].nama);
                        loopCounter++;
                    }
                    loopCounter = 0;

                    indexUMKM = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Anda login di akun UMKM dengan id :" + indexUMKM);
                    Console.WriteLine("Dengan nama :" + arrUMKM[indexUMKM].nama);
                }
                else if (intCek == 7)
                {
                    while (loopCounter <= banyakUMKM)
                    {
                        Console.WriteLine("Berikut adalah array index id UMKM yang sudah disimpan");
                        Console.WriteLine(loopCounter + ". " + arrUMKM[loopCounter].nama);
                        loopCounter++;
                    }
                    loopCounter = 0;
                }
                else if (intCek == 8)
                {
                    arrUMKM[indexUMKM].HapusBarang();
                }
                else if (intCek == 9)
                {
                    arrUMKM[indexUMKM].jumlahproduk(arrUMKM);
                    Console.WriteLine("");
                }
                else if (intCek == 10)
                {
                    BuyerConfig.ReadJson();  
                    
                }
                else if(intCek == 11)
                {
                    Console.WriteLine("Masukkan input berupa Pembeli atau UMKM");
                    stringCek = Console.ReadLine();
                }
            }
        }
    }
}