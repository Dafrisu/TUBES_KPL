using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace UMKMLibrary
{
    public class UMKMLib
    {
        public string nama { get; set; }
        public Dictionary<string, int> Stock { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, string> JenisProduk { get; set; } = new Dictionary<string, string>();

        private const string logFileName = "umkmconfig.json";
        private readonly string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), logFileName);

        public static void WriteJson(UMKMLib newData)
        {
            try
            {
                string[] lines = File.ReadAllLines("umkmconfig.json");
                List<UMKMLib> umkmList = new List<UMKMLib>();

                // Deserialize existing data from the file
                foreach (string line in lines)
                {
                    try
                    {
                        var umkm = JsonSerializer.Deserialize<UMKMLib>(line);
                        umkmList.Add(umkm);
                    }
                    catch (JsonException)
                    {
                        // Skip invalid lines
                    }
                }

                // Check if the username already exists
                var existingUmkm = umkmList.Find(umkm => umkm.nama == newData.nama);
                if (existingUmkm != null)
                {
                    // Update existing data
                    existingUmkm.Stock = newData.Stock;
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
    }
}