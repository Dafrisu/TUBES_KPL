using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Specialized;
namespace Tubes_KPL_Kelompok1;
public class UMKM
{
    public string nama;
    public enum KategoriBarang
    {
        Makanan,
        Minuman,
        Misc
    };

    public Dictionary<KategoriBarang, Dictionary<String, int>> InsertBarang = new Dictionary<KategoriBarang, Dictionary<String, int>>();

    public UMKM(string nama)
    {
        this.nama = nama;
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

    public void TambahStock() {
        Console.WriteLine("Masukkan kategori barang (Makanan, Minuman, Misc):");
        string kategoriString = Console.ReadLine();

        Console.WriteLine("Masukkan nama barang:");
        string namaBarang = Console.ReadLine();

        Console.WriteLine("Masukkan jumlah stok yang ingin ditambahkan ke barang:");
        int stokBarang = Convert.ToInt32(Console.ReadLine());

        KategoriBarang kategori;
        int hasilSekarang;

        if (!Enum.TryParse(kategoriString, out kategori)){
            Console.WriteLine("Kategori Barang tidak ditemukan");
        }
        if (!InsertBarang[kategori].ContainsKey(namaBarang)) {
            Console.WriteLine("Nama Barang tidak ditemukan");
        }
        if (Enum.TryParse(kategoriString, out kategori) && InsertBarang[kategori].ContainsKey(namaBarang)) {
            int jumlahSekarang = InsertBarang[kategori][namaBarang];
            InsertBarang[kategori][namaBarang] = jumlahSekarang + stokBarang;
            hasilSekarang = InsertBarang[kategori][namaBarang];
            Console.WriteLine("Jumlah stok telah ditambah");
            Console.WriteLine("Jumlah Stok sekarang adalah :"+hasilSekarang);
        }
    }
    public void KurangStock()
    {
        Console.WriteLine("Masukkan kategori barang (Makanan, Minuman, Misc):");
        string kategoriString = Console.ReadLine();

        Console.WriteLine("Masukkan nama barang:");
        string namaBarang = Console.ReadLine();

        Console.WriteLine("Masukkan jumlah stok yang akan dikurangkan barang:");
        int stokBarang = Convert.ToInt32(Console.ReadLine());

        KategoriBarang kategori;


        if (!Enum.TryParse(kategoriString, out kategori))
        {
            Console.WriteLine("Kategori Barang tidak ditemukan");
        }
        if (!InsertBarang[kategori].ContainsKey(namaBarang))
        {
            Console.WriteLine("Nama Barang tidak ditemukan");
        }
        if (Enum.TryParse(kategoriString, out kategori) && InsertBarang[kategori].ContainsKey(namaBarang))
        {
            int jumlahSekarang = InsertBarang[kategori][namaBarang];
            int hasilSekarang;
            if (jumlahSekarang <= 0)
            {
                Console.WriteLine("Stok tidak bisa dikurangi karena sudah 0");
            } else if (jumlahSekarang > 0) {
                int tempKurang = jumlahSekarang - stokBarang;
                if (tempKurang >= 0)
                {
                    InsertBarang[kategori][namaBarang] = jumlahSekarang - stokBarang;
                    Console.WriteLine("Jumlah stok telah dikurang");
                    hasilSekarang = InsertBarang[kategori][namaBarang];
                    Console.WriteLine("Jumlah stok sekarang adalah :" + hasilSekarang);
                }
                else if (tempKurang < 0) {
                    InsertBarang[kategori][namaBarang] = 0;
                    hasilSekarang = InsertBarang[kategori][namaBarang];
                    Console.WriteLine("Jumlah stok sekarang adalah :" + hasilSekarang);
                }
            }
        }
    }
}
