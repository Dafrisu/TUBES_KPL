using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UMKMconfig
{
    internal class JsonProcessor
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "barang.json");


        public List<Barang> GetBarangForUser(string user)
        {
            // Membaca JSON dari file
            string jsonData = File.ReadAllText(_filePath);

            // Deserialisasi JSON ke Dictionary
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var penjualDict = JsonSerializer.Deserialize<Dictionary<string, List<Barang>>>(jsonData, options);

            // List untuk menyimpan barang-barang
            List<Barang> listBarang = new List<Barang>();

            // Menambahkan barang ke listBarang jika nama pengguna ditemukan
            if (penjualDict.ContainsKey(user))
            {
                listBarang.AddRange(penjualDict[user]);
            }
            else
            {
                Console.WriteLine("Pengguna tidak ditemukan dalam data JSON.");
            }

            return listBarang;
        }
    }
}
