using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks; 

namespace GUI_APP
{
    internal class UMKMLibGUI
    {
        public string KategoriBarang { get; set; }
        public string NamaProduk { get; set; }

        public Dictionary<string, int> Stock { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> Harga { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, string> JenisProduk { get; set; } = new Dictionary<string, string>();

        private const string logFileName = "umkmconfig.json";
        private readonly string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), logFileName);

        public static void WriteJson(UMKMLibGUI newData)
        {
            try
            {
                List<UMKMLibGUI> umkmList = new List<UMKMLibGUI>();

                if (File.Exists("umkmconfig.json"))
                {
                    string jsonString = File.ReadAllText("umkmconfig.json");
                    umkmList = JsonSerializer.Deserialize<List<UMKMLibGUI>>(jsonString) ?? new List<UMKMLibGUI>();
                }

                // Check if the category already exists
                var existingUmkm = umkmList.Find(umkm => umkm.KategoriBarang == newData.KategoriBarang);
                if (existingUmkm != null)
                {
                    // Update existing data
                    existingUmkm.Stock = newData.Stock;
                    existingUmkm.Harga = newData.Harga;
                    existingUmkm.JenisProduk = newData.JenisProduk;
                }
                else
                {
                    // Add new data
                    umkmList.Add(newData);
                }

                // Serialize the updated data and write it back to the file
                string updatedJson = JsonSerializer.Serialize(umkmList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("umkmconfig.json", updatedJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing JSON file: {ex.Message}");
            }
        }
        public static void ReadJson()
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
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
            }
        }

        public static void ParseJson(string jsonFilePath, List<BarangUMKM> listBarang)
        {
            try
            {


                if (File.Exists(jsonFilePath))
                {
                    string json = File.ReadAllText(jsonFilePath);
                    var parsedData = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, List<BarangUMKM>>>>(json);

                    if (parsedData != null)
                    {
                        foreach (var category in parsedData)
                        {
                            foreach (var product in category.Value)
                            {
                                foreach (var item in product.Value)
                                {
                                    listBarang.Add(new BarangUMKM
                                    (
                                        item.namabarang,
                                        item.stok,
                                        item.harga,
                                        item.kategoriBarang
                                    ));
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File umkmconfig.json not found.");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing JSON file: {ex.Message}");

            }
        }
    }
    
}

