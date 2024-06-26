﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;


namespace Tubes_KPL_Kelompok1
{
    public class BuyerConfig
    {
        public Dictionary<string, Buyer> Pembeli { get; set; }

        public class Buyer
        {
            public Dictionary<string, Dictionary<string, int>> UMKM { get; set; }
        }
        static string jsonFilePath = @"C:\Users\haika\OneDrive\Dokumen\KULIAH\SEMESTER 4\Konstruksi Perangkat Lunak\Tubes\TUBES_KPL\Tubes_KPL_Kelompok1\buyerconfig.json";



        // Baca JSON dari file
        public static string json = File.ReadAllText(jsonFilePath);

        public static void printJson()
        {
            string jsonFilePath = @"C:\Users\haika\OneDrive\Dokumen\KULIAH\SEMESTER 4\Konstruksi Perangkat Lunak\Tubes\TUBES_KPL\Tubes_KPL_Kelompok1\buyerconfig.json";
            // Baca JSON dari file
            string json = File.ReadAllText(jsonFilePath);
            Console.WriteLine(json);
        }
        public static void tambahbarangjson(String umkmname, String buyername, String namabarang, int qty)
        {
            string jsonFilePath = @"C:\Users\haika\OneDrive\Dokumen\KULIAH\SEMESTER 4\Konstruksi Perangkat Lunak\Tubes\TUBES_KPL\Tubes_KPL_Kelompok1\buyerconfig.json";
            // Baca JSON dari file
            string json = File.ReadAllText(jsonFilePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            BuyerConfig config = JsonSerializer.Deserialize<BuyerConfig>(json, options);
            if (config != null && config.Pembeli != null)
            {
                if (config.Pembeli.ContainsKey(buyername))
                {
                    var buyer = config.Pembeli[buyername];

                    if (buyer.UMKM.ContainsKey(umkmname))
                    {
                        var umkm = buyer.UMKM[umkmname];

                        if (umkm.ContainsKey(namabarang))
                        {
                            umkm[namabarang] += qty;
                        }
                        else
                        {
                            umkm[namabarang] = qty;
                        }
                    }
                    else
                    {
                        buyer.UMKM[umkmname] = new Dictionary<string, int> { { namabarang, qty } };
                    }
                } 
                else
                {
                    config.Pembeli[buyername] = new Buyer
                    {
                        UMKM = new Dictionary<string, Dictionary<string, int>>
                                {
                                    { umkmname, new Dictionary<string, int> { { namabarang, qty } } }
                                }
                    };
                }

                // Serialisasi kembali objek menjadi JSON dengan format yang sama seperti aslinya

                string updatedJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });

                // Tulis JSON yang telah diperbarui kembali ke file
                File.WriteAllText(jsonFilePath, updatedJson);

                Console.WriteLine($"Barang '{namabarang}' dengan kuantitas {qty} berhasil ditambahkan ke UMKM '{umkmname}' untuk pembeli '{buyername}'.");
            }
            else
            {
                Console.WriteLine($"Error: Konfigurasi tidak valid atau pembeli '{buyername}' tidak ditemukan.");
            }
        }
        public static void UpdateQuantity(string buyerName, string umkmName, string itemName, int newQuantity)
        {

            string jsonFilePath = @"C:\Users\haika\OneDrive\Dokumen\KULIAH\SEMESTER 4\Konstruksi Perangkat Lunak\Tubes\TUBES_KPL\Tubes_KPL_Kelompok1\buyerconfig.json";

            // Baca JSON dari file
            string json = File.ReadAllText(jsonFilePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            BuyerConfig config = JsonSerializer.Deserialize<BuyerConfig>(json, options);
            if (!config.Pembeli.ContainsKey(buyerName))
            {
                config.Pembeli[buyerName] = new Buyer { UMKM = new Dictionary<string, Dictionary<string, int>>() };
            }

            // Jika nama UMKM tidak ada, tambahkan UMKM baru untuk pembeli
            if (!config.Pembeli[buyerName].UMKM.ContainsKey(umkmName))
            {
                config.Pembeli[buyerName].UMKM[umkmName] = new Dictionary<string, int>();
            }

            // Jika nama barang tidak ada, tambahkan barang baru untuk UMKM
            if (!config.Pembeli[buyerName].UMKM[umkmName].ContainsKey(itemName))
            {
                config.Pembeli[buyerName].UMKM[umkmName][itemName] = newQuantity;
            }
            else
            {
                // Update kuantitas barang
                config.Pembeli[buyerName].UMKM[umkmName][itemName] = newQuantity;
            }

            // Serialisasi kembali objek menjadi JSON dengan format yang sama seperti aslinya
            string updatedJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });

            // Tulis JSON yang telah diperbarui kembali ke file
            File.WriteAllText(jsonFilePath, updatedJson);

            Console.WriteLine($"Kuantitas barang '{itemName}' untuk pembeli '{buyerName}' di UMKM '{umkmName}' berhasil diubah menjadi {newQuantity}.");
        }
    
        
        public static void ReadJson()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            try
            {
                string jsonFilePath = @"C:\Users\haika\OneDrive\Dokumen\KULIAH\SEMESTER 4\Konstruksi Perangkat Lunak\Tubes\TUBES_KPL\Tubes_KPL_Kelompok1\buyerconfig.json";
                string json = File.ReadAllText(jsonFilePath);
                if (jsonFilePath != null)
                {
                    BuyerConfig config = JsonSerializer.Deserialize<BuyerConfig>(json, options);
                    if (config != null && config.Pembeli != null)
                    {
                        foreach (var pembeli in config.Pembeli)
                        {
                            Console.WriteLine($"Pembeli: {pembeli.Key}");

                            foreach (var umkm in pembeli.Value.UMKM)
                            {
                                Console.WriteLine($"UMKM: {umkm.Key}");

                                foreach (var barang in umkm.Value)
                                {
                                    Console.WriteLine($"   Barang: {barang.Key}, Qty: {barang.Value}");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Gagal membaca konfigurasi pembeli.");
                    }
                }
                else
                {
                    throw new Exception("File Json NULL");
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
           
        }
    }
}
