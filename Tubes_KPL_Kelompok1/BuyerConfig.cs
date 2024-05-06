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
    public class BuyerConfig
    {

        public void UpdateQuantity(string buyerName, string itemName, int newQuantity)
        {
            string jsonFilePath = @"C:\Users\haika\OneDrive\Dokumen\KULIAH\SEMESTER 4\Konstruksi Perangkat Lunak\Tubes\TUBES_KPL\Tubes_KPL_Kelompok1\buyerconfig.json";

            // Baca JSON dari file
            string json = File.ReadAllText(jsonFilePath);

            KeranjangConfig keranjangConfig = JsonSerializer.Deserialize<KeranjangConfig>(json);

            // Periksa apakah nama pembeli ada dalam konfigurasi
            if (keranjangConfig != null && keranjangConfig.Keranjang.ContainsKey(buyerName))
            {
                // Periksa apakah nama barang ada dalam keranjang pembeli
                if (keranjangConfig.Keranjang[buyerName].ContainsKey(itemName))
                {
                    // Update kuantitas barang
                    keranjangConfig.Keranjang[buyerName][itemName] = newQuantity;

                    // Serialisasi kembali objek menjadi JSON dengan format yang sama seperti aslinya
                    string updatedJson = JsonSerializer.Serialize(keranjangConfig, new JsonSerializerOptions { WriteIndented = true });

                    // Tulis JSON yang telah diperbarui kembali ke file
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
            String json = File.ReadAllText(@"C:\Users\haika\OneDrive\Dokumen\KULIAH\SEMESTER 4\Konstruksi Perangkat Lunak\Tubes\TUBES_KPL\Tubes_KPL_Kelompok1\buyerconfig.json");
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
