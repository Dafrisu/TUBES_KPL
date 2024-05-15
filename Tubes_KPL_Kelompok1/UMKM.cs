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
    public Dictionary<string, string> JenisProduk { get; set; } = new Dictionary<string, string>();

    private const string logFileName = "umkmconfig.json";
    private readonly string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), logFileName);
    private readonly System.Timers.Timer autoUpdateTimer;

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

        if (!Enum.TryParse(typeof(KategoriBarang), kategoriString, true, out var kategori))
        {
            Console.WriteLine("Kategori barang tidak valid.");
            return;
        }

        if (Stock.ContainsKey(namaBarang))
        {
            Console.WriteLine($"Barang '{namaBarang}' sudah ada. Menambah stok.");
            Stock[namaBarang] += stokBarang;
        }
        else
        {
            Stock[namaBarang] = stokBarang;
            JenisProduk[namaBarang] = kategoriString;
        }

        LogAction("Tambah Barang", namaBarang, stokBarang);
        SaveData();
    }

    public void GetBarang()
    {
        Console.WriteLine("Nama UMKM: " + this.Username);
        Console.WriteLine("Nama Barang\tStok Barang\tKategori Barang");

        foreach (var barang in Stock)
        {
            string kategori = JenisProduk.ContainsKey(barang.Key) ? JenisProduk[barang.Key] : "Unknown";
            Console.WriteLine($"{barang.Key}\t\t{barang.Value}\t\t{kategori}");
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
        Console.WriteLine("Masukkan nama barang:");
        string namaBarang = Console.ReadLine();

        Console.WriteLine($"Masukkan jumlah stok yang ingin {action.ToLower()}kan:");
        int stokBarang = Convert.ToInt32(Console.ReadLine());

        if (Stock.ContainsKey(namaBarang))
        {
            if (action == "Tambah Stok")
            {
                Stock[namaBarang] += stokBarang;
            }
            else if (action == "Kurang Stok")
            {
                Stock[namaBarang] = Math.Max(0, Stock[namaBarang] - stokBarang);
            }

            LogAction(action, namaBarang, stokBarang);
            SaveData();
        }
        else
        {
            Console.WriteLine($"Barang '{namaBarang}' tidak ditemukan.");
        }
    }

    private void AutoUpdateStock(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("Auto updating stock...");

        foreach (var barang in Stock.Keys)
        {
            Stock[barang] += 10; 
        }

        SaveData();
        Console.WriteLine("Stock updated automatically.");
    }

    private void LogAction(string action, string namaBarang, int stokBarang)
    {
        string logMessage = $"{DateTime.Now}: {action} - Nama Barang: {namaBarang}, Jumlah: {stokBarang}";
        File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
    }

    public void SaveData()
    {
        List<UMKM> umkmList = new List<UMKM>();

        if (File.Exists(logFilePath))
        {
            try
            {
                string json = File.ReadAllText(logFilePath);
                if (!string.IsNullOrEmpty(json))
                {
                    umkmList = JsonSerializer.Deserialize<List<UMKM>>(json);
                }
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON format error: {jsonEx.Message}");
                
                umkmList = new List<UMKM>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                
                umkmList = new List<UMKM>();
            }
        }

        var existingUmkm = umkmList.Find(umkm => umkm.Username == this.Username);
        if (existingUmkm != null)
        {
            existingUmkm.Stock = this.Stock;
            existingUmkm.JenisProduk = this.JenisProduk;
        }
        else
        {
            umkmList.Add(this);
        }

        try
        {
            string updatedJson = JsonSerializer.Serialize(umkmList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(logFilePath, updatedJson);
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
            string[] lines = File.ReadAllLines("umkmconfig.json");
            foreach (string line in lines)
            {
                try
                {
                    var umkm = JsonSerializer.Deserialize<UMKM>(line);
                    Console.WriteLine($"Username: {umkm.Username}");
                    Console.WriteLine($"Stock: {string.Join(", ", umkm.Stock)}");
                    Console.WriteLine($"JenisProduk: {string.Join(", ", umkm.JenisProduk)}");
                }
                catch (JsonException)
                {
                    
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"");
        }
    }



    public enum KategoriBarang
    {
        Makanan,
        Minuman,
        Misc
    }
}


