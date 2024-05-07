using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
//using static Tubes_KPL_Kelompok1.Pembeli;
namespace Tubes_KPL_Kelompok1;
public class UMKM
{
    public string nama;
    //public KategoriBarang a;
    public enum KategoriBarang
    {
        Makanan,
        Minuman,
        Misc
    };

    public Dictionary<KategoriBarang, Dictionary<String, int>> InsertBarang = new Dictionary<KategoriBarang, Dictionary<String, int>>();

    public UMKM(string nama)//, KategoriBarang a)
    {
        this.nama = nama;

        //this.a = a;
    }

    public void TambahBarang()
    {
        Console.WriteLine("Masukkan nama barang:");
        string namaBarang = Console.ReadLine();

        Console.WriteLine("Masukkan stok barang:");
        int stokBarang = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Masukkan kategori barang (Makanan, Minuman, Misc):");
        string kategoriString = Console.ReadLine();

        // Ubah input kategori menjadi enum
        KategoriBarang kategori;
        if (!Enum.TryParse(kategoriString, out kategori))
        {
            Console.WriteLine("Kategori barang tidak valid.");
            return;
        }

        // Periksa apakah kategori barang sudah ada di dictionary
        if (!InsertBarang.ContainsKey(kategori))
        {
            // Jika belum, tambahkan kategori baru
            InsertBarang[kategori] = new Dictionary<string, int>();
        }

        // Tambahkan barang baru
        InsertBarang[kategori][namaBarang] = stokBarang;
    }

    public void GetBarang()
    {
        Console.WriteLine("Nama UMKM: " + this.nama);
        Console.WriteLine("Nama Barang\tStok barang");

        foreach (KategoriBarang kategori in Enum.GetValues(typeof(KategoriBarang)))
        {
            if (InsertBarang.ContainsKey(kategori))
            {
                foreach (KeyValuePair<string, int> barang in InsertBarang[kategori])
                {
                    Console.WriteLine(barang.Key + "\t\t" + barang.Value);
                }
            }
        }
    }
}
