using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        { namaBarang.SodaGembira, 10 },
        { namaBarang.SemurJengkol, 11 },
        { namaBarang.Kikil, 10},
        { namaBarang.SotoAyam, 11},
        { namaBarang.MieGacoan, 10}
    };
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
    }
}
