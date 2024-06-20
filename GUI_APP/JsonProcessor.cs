using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace GUI_APP
{
    internal class JsonProcessor
    {

        string _filePath = "ListUMKM.json";

        public List<Barang> GetBarangForUser(string userName)
        {
            try
            {
                // Membaca JSON dari file
                string jsonData = File.ReadAllText(_filePath);

                // Deserialisasi JSON ke Dictionary<string, List<Barang>>
                var options = new JsonSerializerOptions { IncludeFields = true };
                var penjualDict = JsonSerializer.Deserialize<Dictionary<string, List<Barang>>>(jsonData, options);

                // List untuk menyimpan barang-barang
                List<Barang> listBarang = new List<Barang>();

                // Menambahkan barang ke listBarang jika nama pengguna ditemukan sebagai key dalam Dictionary
                if (penjualDict.ContainsKey(userName))
                {
                    listBarang.AddRange(penjualDict[userName]);
                }
                else
                {
                    MessageBox.Show("Pengguna tidak ditemukan dalam data JSON.");
                }

                return listBarang;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return new List<Barang>();
            }
        }
    }
}
