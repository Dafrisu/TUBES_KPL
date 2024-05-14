
﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Tubes_KPL_Kelompok1;
using Keranjang;
using static Tubes_KPL_Kelompok1.UMKM;
using static Tubes_KPL_Kelompok1.IdentifyUser;

class program
{
    void Main(string[] args)
    {
        String stringCek;
        int intCek = 0;
        IdentifyUser cek = new IdentifyUser();
        stringCek = Console.ReadLine();
        bool umkmInstanceExists = false;
        UMKM[] arrUMKM = new UMKM[20];
        KeranjangPembeli keranjang = new KeranjangPembeli();
        KeranjangPembeli.Manage manage = new KeranjangPembeli.Manage();
        int indexUMKM = 0;
        int banyakUMKM = 0;
        string namaUMKM;
        int loopCounter = 0;
        BuyerConfig buyer = new BuyerConfig();

        while (intCek != 11)
        {
            if (stringCek.Equals("Pembeli"))
            {
                cek.Pembeli();
                Pembeli a = new Pembeli("Haikal");
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
                    a.tambahBarang(arrUMKM[indexUMKM]);
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
            else if (stringCek.Equals("UMKM"))
            {
                cek.UMKM();

                if (!umkmInstanceExists) // Memeriksa apakah instance UMKM sudah ada
                {
                    Console.WriteLine("Masukkan nama UMKM");
                    namaUMKM = Console.ReadLine();
                    arrUMKM[indexUMKM] = new UMKM(namaUMKM);
                    Console.WriteLine("Anda login di akun UMKM dengan id :" + indexUMKM);
                    Console.WriteLine("Dengan nama :" + arrUMKM[indexUMKM].nama);
                    umkmInstanceExists = true;
                }


                Console.WriteLine("Fitur Untuk UMKM ");
                Console.WriteLine("1. Tambah Barang: ");
                Console.WriteLine("2. Print Barang UMKM");
                Console.WriteLine("3. Tambah Stok Barang");
                Console.WriteLine("4. Kurang Stok Barang");
                Console.WriteLine("5. Tambah Akun UMKM");
                Console.WriteLine("6. Ganti login akun UMKM (Menggunakan Index)");
                Console.WriteLine("7. Tampilkan Index dan nama sesuai dengan Index");
                Console.WriteLine("9. Lihat Log");
                Console.WriteLine("10. UMKM dan Jumlah Barang");
                Console.WriteLine("8. Ganti Tipe User");
                Console.WriteLine("11. Keluar dari program");
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
                    buyer.readjson();
                }
                else if (intCek == 9)
                {
                    arrUMKM[indexUMKM].jumlahproduk(arrUMKM);
                }
                else if (intCek == 10)
                {
                    Console.WriteLine("Masukkan input berupa Pembeli atau UMKM");
                    stringCek = Console.ReadLine();
                }
            }
        }
    }
}