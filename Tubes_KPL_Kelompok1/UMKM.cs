using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Tubes_KPL_Kelompok1
{
    public class UMKM
    {
        public string nama;
        public UMKM(string nama) { 
            this.nama = nama;
        }
        public enum namaBarang { SodaGembira, SemurJengkol, Kikil, SotoAyam, MieGacoan };

        Dictionary<namaBarang, int> stock = new Dictionary<namaBarang, int>()
    {
        
    };
        public void TambahBarang()
        {
            int idx = Enum.GetValues(typeof(namaBarang)).Length - 1;
            String nama;
            int stok;
            nama = Console.ReadLine();
            stok = Convert.ToInt32(Console.ReadLine());
            // add EnumValue
            stock.Add((namaBarang)idx, stok);
        }
        public void GetBarang()
        {
            Console.WriteLine("Nama UMKM"+"\t:"+this.nama);
            Console.WriteLine("Nama Barang"+"\t"+"Stok barang");
            for (int i = 0; i < Enum.GetNames(typeof(namaBarang)).Length; i++)
            {
                namaBarang currentBarang = (namaBarang)i;
                string output = currentBarang.ToString().PadRight(15);
                Console.WriteLine(output + "\t:" + stock[currentBarang].ToString());
                Console.WriteLine();
            }
        }
        /*
        static void AddEnumValue<T>(string enumValue, int stok) where T : Enum
        {
            Enum.TryParse(enumValue, out T result);
            stock.Add(result, stok);
        }
        */
    }
}
