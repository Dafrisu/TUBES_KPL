using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Tubes_KPL_Kelompok1;
public class UMKM
{
    public string nama;

    public enum NamaBarang
    {
        SodaGembira,
        SemurJengkol,
        Kikil,
        SotoAyam,
        MieGacoan
    };

    Dictionary<NamaBarang, int> stock = new Dictionary<NamaBarang, int>();

    public UMKM(string nama)
    {
        this.nama = nama;
    }

    public void TambahStockBarang()
    {
        Console.WriteLine("Masukkan nama barang:");
        string nama = Console.ReadLine();

        Console.WriteLine("Masukkan stok barang:");
        int stok = Convert.ToInt32(Console.ReadLine());

        NamaBarang namaBarang;

        if (Enum.TryParse(nama, out namaBarang))
        {
            if (stock.ContainsKey(namaBarang))
            {
                stock[namaBarang] += stok; // Update stok jika barang sudah ada
            }
            else
            {
                stock.Add(namaBarang, stok); // Tambahkan barang baru
            }
        }
        else
        {
            Console.WriteLine("Barang tidak valid.");
        }
    }

    public void GetBarang()
    {
        Console.WriteLine("Nama UMKM: " + this.nama);
        Console.WriteLine("Nama Barang\tStok barang");

        foreach (NamaBarang barang in Enum.GetValues(typeof(NamaBarang)))
        {
            Console.WriteLine(barang.ToString() + "\t\t" + (stock.ContainsKey(barang) ? stock[barang].ToString() : "0"));
        }
    }
}
