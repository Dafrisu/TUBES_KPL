using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMKMconfig
{
    internal class TempBarang
    {
        public static List<Barang> baranglist = new List<Barang>();

        public static void setbarang()
        {
            string filePath = "barang.json";
            // Deserialisasi JSON ke Dictionary
            JsonProcessor processor = new JsonProcessor();

            // Nama pengguna yang dicari
            string user = "Darryl";

            // Mendapatkan barang-barang untuk pengguna tertentu
            TempBarang.baranglist = processor.GetBarangForUser(user);

            
        }
    }
}
