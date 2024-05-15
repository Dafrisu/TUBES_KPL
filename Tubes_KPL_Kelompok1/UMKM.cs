using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;
using System.Timers;

namespace Tubes_KPL_Kelompok1;
public class UMKM
{
    public string Username { get; set; }
    public Dictionary<string, int> Stock { get; set; } = new Dictionary<string, int>();
    public enum KategoriBarang
    {
        Makanan,
        Minuman,
        Misc
    };

    public Dictionary<KategoriBarang, Dictionary<string, int>> InsertBarang { get; set; } = new Dictionary<KategoriBarang, Dictionary<string, int>>();
    private const string logFileName = "umkmconfig.json";
    private readonly string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), logFileName);
    private System.Timers.Timer autoUpdateTimer;


    public class Buyer
    {
        public Dictionary<string, int> BarangYangDibeli { get; set; } = new Dictionary<string, int>();
    }

    public class UMKMData
    {
        public Buyer Buyer { get; set; } = new Buyer();
    }

    public UMKM(string username)
    {
        this.Username = username;
        autoUpdateTimer = new System.Timers.Timer(3600000);
        autoUpdateTimer.Elapsed += AutoUpdateStock;
        autoUpdateTimer.Start();
    }

    public void TambahBarang()
    {
        Console.WriteLine("Masukkan nama barang:");
        string namaBarang = Console.ReadLine();

        Console.WriteLine("Masukkan stok barang:");
        int stokBarang = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Masukkan kategori barang (Makanan, Minuman, Misc):");
        string kategoriString = Console.ReadLine();

        if (!Enum.TryParse(kategoriString, out KategoriBarang kategori))
        {
            Console.WriteLine("Kategori barang tidak valid.");
            return;
        }

        if (!InsertBarang.ContainsKey(kategori))
        {
            InsertBarang[kategori] = new Dictionary<string, int>();
        }

        InsertBarang[kategori][namaBarang] = stokBarang;
        LogAction("Tambah Barang", namaBarang, stokBarang);
        SaveData();
    }

    public void GetBarang()
    {
        Console.WriteLine("Nama UMKM: " + this.Username);
        Console.WriteLine("Nama Barang\tStok barang");

        foreach (var kategori in InsertBarang)
        {
            foreach (var barang in kategori.Value)
            {
                Console.WriteLine($"{barang.Key}\t\t{barang.Value}");
            }
        }
    }

    public void TambahStok()
    {
        UpdateStok("Tambah Stok");
    }

    public void KurangStok()
    {
        UpdateStok("Kurang Stok");
    }

    private void UpdateStok(string action)
    {
        Console.WriteLine("Masukkan kategori barang (Makanan, Minuman, Misc):");
        string kategoriString = Console.ReadLine();

        Console.WriteLine("Masukkan nama barang:");
        string namaBarang = Console.ReadLine();

        Console.WriteLine($"Masukkan jumlah stok yang ingin {action.ToLower()}kan ke barang:");
        int stokBarang = Convert.ToInt32(Console.ReadLine());

        if (!Enum.TryParse(kategoriString, out KategoriBarang kategori))
        {
            Console.WriteLine("Kategori barang tidak valid.");
            return;
        }

        if (InsertBarang.ContainsKey(kategori) && InsertBarang[kategori].ContainsKey(namaBarang))
        {
            if (action == "Tambah Stok")
            {
                InsertBarang[kategori][namaBarang] += stokBarang;
            }
            else if (action == "Kurang Stok")
            {
                InsertBarang[kategori][namaBarang] = Math.Max(0, InsertBarang[kategori][namaBarang] - stokBarang);
            }

            LogAction(action, namaBarang, stokBarang);
            SaveData();
        }
        else
        {
            Console.WriteLine($"Barang '{namaBarang}' tidak ditemukan dalam kategori '{kategoriString}'.");
        }
    }

    private void AutoUpdateStock(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("Auto updating stock...");

        foreach (var kategori in InsertBarang.Keys)
        {
            foreach (var barang in InsertBarang[kategori].Keys)
            {
                InsertBarang[kategori][barang] += 10; // Example logic: add 10 to each item's stock
            }
        }

        SaveData();
        Console.WriteLine("Stock updated automatically.");
    }

    private void LogAction(string action, string namaBarang, int stokBarang)
    {
        string logMessage = $"{DateTime.Now}: {action} - Nama Barang: {namaBarang}, Jumlah: {stokBarang}";
        File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
    }

    private void SaveData()
    {
        string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(logFilePath, json);
    }

    public void ReadJson()
    {
        try
        {
            string json = File.ReadAllText(logFilePath);
            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }



}
