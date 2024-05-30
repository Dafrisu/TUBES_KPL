using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Tubes_KPL_Kelompok1;
using Keranjang;
using static Tubes_KPL_Kelompok1.UMKM;
using static Tubes_KPL_Kelompok1.IdentifyUser;

class programe
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
        KeranjangPembeli keranjang = new KeranjangPembeli();
        stateAplikasi stateAplikasi = new stateAplikasi();

        //Initial run
        
        
        
        
        

        while (intCek != 23)
        {
            try
            {
                IdentifyUser cek = new IdentifyUser();
                stringCek = Console.ReadLine();
                if (stringCek.Equals("Pembeli"))
                {
                    cek.Pembeli();
                    stateAplikasi.FiturPembeli();
                    if (!pembeliInstanceExists) // Memeriksa apakah instance UMKM sudah ada
                    {
                        Console.WriteLine("Masukkan nama Pembeli");
                        namaPembeli = Console.ReadLine();
                        arrPembeli[indexPembeli] = new Pembeli(namaPembeli);
                        Console.WriteLine("Anda login di akun Pembeli dengan id :" + indexPembeli);
                        Console.WriteLine("Dengan nama :" + arrPembeli[indexPembeli].nama);
                        pembeliInstanceExists = true;
                    }
                    Console.WriteLine("Fitur Untuk Pembeli :");
                    Console.WriteLine("1. Tambah barang yang dipesan ");
                    Console.WriteLine("2. Print Keranjang");
                    Console.WriteLine("3. Search barang");
                    Console.WriteLine("4. Tambah Akun Pembeli");
                    Console.WriteLine("5. Ganti login akun Pembeli (Menggunakan Index)");
                    Console.WriteLine("6. Tampilkan Index dan nama sesuai dengan Index");
                    Console.WriteLine("7. Edit Keranjang");
                    Console.WriteLine("8. Masukan Data Ke keranjang Json");
                    Console.WriteLine("9. Tampilkan Json");
                    Console.WriteLine("10. Login sebagai User yang lain");
                    Console.WriteLine("23. Keluar dari Program");
                    try
                    {
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
                            arrPembeli[indexPembeli].searchKeranjang(arrUMKM);
                        }
                        else if (intCek == 4)
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
                        else if (intCek == 5)
                        {
                            Console.WriteLine("Masukkan input berupa Int index yang tersedia");
                            while (loopCounter <= banyakPembeli)
                            {
                                Console.WriteLine("Berikut adalah array index id Pembeli yang sudah disimpan");
                                Console.WriteLine(loopCounter + ". " + arrPembeli[loopCounter].nama);
                                loopCounter++;
                            }
                            loopCounter = 0;

                            indexPembeli = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Anda login di akun UMKM dengan id :" + indexPembeli);
                            Console.WriteLine("Dengan nama :" + arrPembeli[indexPembeli].nama);

                        }
                        else if (intCek == 6)
                        {
                            Console.WriteLine("Berikut adalah array index id UMKM yang sudah disimpan");
                            while (loopCounter <= banyakPembeli)
                            {
                                Console.WriteLine(loopCounter + ". " + arrPembeli[loopCounter].nama);
                                loopCounter++;
                            }
                            loopCounter = 0;
                        }
                        else if (intCek == 7)
                        {
                            arrPembeli[indexPembeli].EditKeranjang();
                        }
                        else if (intCek == 8)
                        {

                            Console.WriteLine("Masukan Nama Barang: ");
                            String namabarang = Console.ReadLine();

                            Console.WriteLine("Masukan Jumlah Barang: ");
                            int qty = Convert.ToInt32(Console.ReadLine());
                            BuyerConfig.tambahbarangjson("dafa", arrPembeli[indexPembeli].nama, namabarang, qty);
                        }
                        else if (intCek == 9)
                        {
                            BuyerConfig.ReadJson();
                        }
                        else if (intCek == 10)
                        {
                            Console.WriteLine("Masukkan input berupa Pembeli atau UMKM atau Admin");
                            stringCek = Console.ReadLine();
                        }
                        else if (intCek == 23)
                        {

                        }
                        else
                        {
                            throw new Exception("Input Tidak Valid");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }


                }
                else if (stringCek.Equals("UMKM"))
                {
                    cek.UMKM();
                    stateAplikasi.FiturUMKM();
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
                    Console.WriteLine("15. Keluar dari program");
                    try
                    {
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
                            UMKM.read();

                        }
                        else if (intCek == 11)
                        {
                            Console.WriteLine("Masukkan input berupa Pembeli atau UMKM atau Admin");
                            stringCek = Console.ReadLine();
                        }
                        else if (intCek == 23)
                        {

                        }
                        else
                        {
                            throw new Exception("Input Tidak Valid");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                }else if (stringCek.Equals("Admin")){
                    cek.Admin();
                    stateAplikasi.FiturAdmin();
                    Console.WriteLine("Priviledge Admin");
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
                    Console.WriteLine("12. Tambah barang yang dipesan ");
                    Console.WriteLine("13. Print Keranjang");
                    Console.WriteLine("14. Search barang");
                    Console.WriteLine("15. Tambah Akun Pembeli");
                    Console.WriteLine("17. Ganti login akun Pembeli (Menggunakan Index)");
                    Console.WriteLine("18. Tampilkan Index dan nama sesuai dengan Index");
                    Console.WriteLine("19. Edit Keranjang");
                    Console.WriteLine("20. Masukan Data Ke keranjang Json");
                    Console.WriteLine("21. Tampilkan Json");
                    Console.WriteLine("22. Login sebagai User yang lain");
                    Console.WriteLine("23. Keluar dari Program");
                    intCek = Convert.ToInt32(Console.ReadLine());
                    try {
                        if (intCek == 11)
                        {
                            Console.WriteLine("Masukkan input berupa Pembeli atau UMKM atau Admin");
                            stringCek = Console.ReadLine();
                        }
                        else if(intCek == 23)
                        {

                        }
                        else
                        {
                            throw new Exception("Input tidak Valid");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    } 
                    { 
                    
                    }
                }
                else
                {
                    throw new Exception("Inputan Salah");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}