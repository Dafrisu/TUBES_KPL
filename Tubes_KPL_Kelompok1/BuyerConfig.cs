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
        public Dictionary<string, Dictionary<string, int>> Keranjang { get; set; }
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

        private readonly string jsonFilePath;

        public BuyerConfig(string path)
        {
            jsonFilePath = path;
        }

        public void UpdateQuantity(string buyerName, string itemName, int newQuantity)
        {
            string json = File.ReadAllText(jsonFilePath);
            KeranjangConfig keranjangConfig = JsonSerializer.Deserialize<KeranjangConfig>(json);

            if (keranjangConfig != null && keranjangConfig.Keranjang.ContainsKey(buyerName))
            {
                if (keranjangConfig.Keranjang[buyerName].ContainsKey(itemName))
                {
                    keranjangConfig.Keranjang[buyerName][itemName] = newQuantity;
                    string updatedJson = JsonSerializer.Serialize(keranjangConfig, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonFilePath, updatedJson);
                    Console.WriteLine($"Kuantitas barang '{itemName}' untuk pembeli '{buyerName}' berhasil diubah menjadi {newQuantity}.");
                }
                else
                {
                    Console.WriteLine($"Error: Barang '{itemName}' tidak ditemukan dalam keranjang pembeli '{buyerName}'.");
                }
            }
            else
            {
                Console.WriteLine($"Error: Pembeli '{buyerName}' tidak ditemukan dalam konfigurasi.");
            }
        }
        public void readjson()
        {
            String json = File.ReadAllText(@"E:\TELKOM UNIVERSITY\TUGAS KULIAH\KONSTRUKSI PERANGKAT LUNAK (KPL)\TUBES\TUBES_KPL\Tubes_KPL_Kelompok1\buyerconfig.json");
            Console.WriteLine(json);
            KeranjangConfig configkeranjang = JsonSerializer.Deserialize<KeranjangConfig>(json);
            if (configkeranjang != null && configkeranjang.Keranjang != null)
            {
                foreach (var pembeli in configkeranjang.Keranjang)
                {
                    Console.WriteLine($"Pembeli: {pembeli.Key}");
                    foreach (var barang in pembeli.Value)
                    {
                        Console.WriteLine($"   Barang: {barang.Key}, Qty: {barang.Value}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Gagal membaca konfigurasi pembeli.");
            }
        }

        public void ReadJson()
        {
            string json = File.ReadAllText(jsonFilePath);
            Console.WriteLine(json);
            KeranjangConfig configkeranjang = JsonSerializer.Deserialize<KeranjangConfig>(json);
            if (configkeranjang != null && configkeranjang.Keranjang != null)
            {
                foreach (var pembeli in configkeranjang.Keranjang)
                {
                    Console.WriteLine($"Pembeli: {pembeli.Key}");
                    foreach (var barang in pembeli.Value)
                    {
                        Console.WriteLine($"   Barang: {barang.Key}, Qty: {barang.Value}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Gagal membaca konfigurasi pembeli.");
            }
        }
    }
}
