using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;


namespace Tubes_KPL_Kelompok1
{

    public class KeranjangConfig
    {
            
    }
    public class LogEntry
    {
        public string BuyerName { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class BuyerConfig
    {
        public Dictionary<string, Dictionary<string, Dictionary<string, int>>> Pembeli { get; set; }

        public static void UpdateQuantity(string buyerName, string umkmName, string itemName, int newQuantity)
        {
            string jsonFilePath = @"E:\TELKOM UNIVERSITY\TUGAS KULIAH\KONSTRUKSI PERANGKAT LUNAK (KPL)\TUBES\TUBES_KPL\Tubes_KPL_Kelompok1\buyerconfig.json";

            // Baca JSON dari file
            string json = File.ReadAllText(jsonFilePath);

            BuyerConfig config = JsonSerializer.Deserialize<BuyerConfig>(json);

            // Periksa apakah nama pembeli ada dalam konfigurasi
            if (config != null && config.Pembeli != null && config.Pembeli.ContainsKey(buyerName))
            {
                // Periksa apakah nama UMKM ada dalam keranjang pembeli
                if (config.Pembeli[buyerName].ContainsKey(umkmName))
                {
                    // Periksa apakah nama barang ada dalam UMKM
                    if (config.Pembeli[buyerName][umkmName].ContainsKey(itemName))
                    {
                        // Update kuantitas barang
                        config.Pembeli[buyerName][umkmName][itemName] = newQuantity;

                        // Serialisasi kembali objek menjadi JSON dengan format yang sama seperti aslinya
                        string updatedJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });

                        // Tulis JSON yang telah diperbarui kembali ke file
                        File.WriteAllText(jsonFilePath, updatedJson);

                        Console.WriteLine($"Kuantitas barang '{itemName}' untuk pembeli '{buyerName}' di UMKM '{umkmName}' berhasil diubah menjadi {newQuantity}.");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Barang '{itemName}' tidak ditemukan dalam UMKM '{umkmName}' untuk pembeli '{buyerName}'.");
                    }
                }
                else
                {
                    Console.WriteLine($"Error: UMKM '{umkmName}' tidak ditemukan dalam keranjang pembeli '{buyerName}'.");
                }
            }
            else
            {
                Console.WriteLine($"Error: Pembeli '{buyerName}' tidak ditemukan dalam konfigurasi.");
            }
        }
        public static void ReadJson()
        {
            string jsonFilePath = @"E:\TELKOM UNIVERSITY\TUGAS KULIAH\KONSTRUKSI PERANGKAT LUNAK (KPL)\TUBES\TUBES_KPL\Tubes_KPL_Kelompok1\buyerconfig.json";
            string json = File.ReadAllText(jsonFilePath);
            Console.WriteLine(json);
            BuyerConfig config = JsonSerializer.Deserialize<BuyerConfig>(json);
            if (config != null && config.Pembeli != null)
            {
                foreach (var pembeli in config.Pembeli)
                {
                    Console.WriteLine($"Pembeli: {pembeli.Key}");
                    foreach (var umkm in pembeli.Value)
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

        public void readLogs()
        {
            string logFilePath = @"E:\TELKOM UNIVERSITY\TUGAS KULIAH\KONSTRUKSI PERANGKAT LUNAK (KPL)\TUBES\TUBES_KPL\Tubes_KPL_Kelompok1\buyerconfig.json";
            if (File.Exists(logFilePath))
            {
                string logJson = File.ReadAllText(logFilePath);
                List<LogEntry> logs = JsonSerializer.Deserialize<List<LogEntry>>(logJson);
                foreach (var log in logs)
                {
                    Console.WriteLine($"{log.Timestamp}: {log.BuyerName} updated {log.ItemName} to {log.Quantity}");
                }
            }
            else
            {
                Console.WriteLine("No log entries found.");
            }
        }
    }
}
