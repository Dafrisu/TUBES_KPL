using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Timers;

namespace Tubes_KPL_Kelompok1;
public class UMKM
{
    public string nama { get; set; }
    public Dictionary<string, int> Stock { get; set; } = new Dictionary<string, int>();
    public Dictionary<string, string> JenisProduk { get; set; } = new Dictionary<string, string>();

    private const string logFileName = "umkmconfig.json";
    private readonly string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), logFileName);
    private readonly System.Timers.Timer autoUpdateTimer;
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
        autoUpdateTimer = new System.Timers.Timer(3600000);
        autoUpdateTimer.Elapsed += AutoUpdateStock;
        autoUpdateTimer.Start();
    }

    public void TambahBarang()
    {
        try
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
               throw new Exception("Kategori barang tidak valid.");
               return;
            }
            //Periksa apakah kategori barang sudah ada di dictionary
            if (!InsertBarang.ContainsKey(kategori))
            {
                //Jika belum, tambahkan kategori baru
                InsertBarang[kategori] = new Dictionary<string, int>();
            }

            //Tambahkan barang baru
            InsertBarang[kategori][namaBarang] = stokBarang;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            
        }
    }

    public String GetBarang()
    {        
        try
        {
            // Menampilkan barang yang dimiliki oleh UMKM
        Console.WriteLine("Nama UMKM: " + this.nama);
        Console.WriteLine("Nama Barang\tStok barang");

            if(InsertBarang.Count == 0)
            {
                throw new Exception("UMKM belum memiliki barang");
                
            }
            else
            {
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
                return "berhasil";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "Gagal";
        }
        
    }

    public void TambahStock() {
        KategoriBarang kategori;
        int hasilSekarang;
        try
        {
            Console.WriteLine("Masukkan kategori barang (Makanan, Minuman, Misc):");
            string kategoriString = Console.ReadLine();
            if (!Enum.TryParse(kategoriString, out kategori))
            {
                throw new Exception("Kategori Barang tidak ditemukan");
            }
            Console.WriteLine("Masukkan nama barang:");
            string namaBarang = Console.ReadLine();
            if (!InsertBarang[kategori].ContainsKey(namaBarang))
            {
                throw new Exception("Nama Barang tidak ditemukan");
            }
            Console.WriteLine("Masukkan jumlah stok yang ingin ditambahkan ke barang:");
            int stokBarang = Convert.ToInt32(Console.ReadLine());
            if (Enum.TryParse(kategoriString, out kategori) && InsertBarang[kategori].ContainsKey(namaBarang))
            {
                int jumlahSekarang = InsertBarang[kategori][namaBarang];
                InsertBarang[kategori][namaBarang] = jumlahSekarang + stokBarang;
                hasilSekarang = InsertBarang[kategori][namaBarang];
                Console.WriteLine("Jumlah stok telah ditambah");
                Console.WriteLine("Jumlah Stok sekarang adalah :" + hasilSekarang);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void KurangStock()
    {
        KategoriBarang kategori;
        // Mengurangi jumlah stok barang
        Console.WriteLine("Masukkan kategori barang (Makanan, Minuman, Misc):");
        string kategoriString = Console.ReadLine();
        if (!Enum.TryParse(kategoriString, out kategori))
        {
            Console.WriteLine("Kategori Barang tidak ditemukan");
        }

        Console.WriteLine("Masukkan nama barang:");
        string namaBarang = Console.ReadLine();
        if (!InsertBarang[kategori].ContainsKey(namaBarang))
        {
            Console.WriteLine("Nama Barang tidak ditemukan");
        }

        Console.WriteLine("Masukkan jumlah stok yang akan dikurangkan barang:");
        int stokBarang = Convert.ToInt32(Console.ReadLine());
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

        var existingUmkm = umkmList.Find(umkm => umkm.nama == this.nama);
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

    public static void WriteJson()
    {
        try
        {
            string[] lines = File.ReadAllLines("umkmconfig.json");
            foreach (string line in lines)
            {
                try
                {
                    var umkm = JsonSerializer.Deserialize<UMKM>(line);
                    Console.WriteLine($"Username: {umkm.nama}");
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
    public static void ReadJson()
    {
        try
        {
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "umkmconfig.json");
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine("File umkmconfig.json tidak ditemukan.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    public void jumlahproduk(UMKM[] input)
    {
        // Menghitung jumlah barang yang dimiliki oleh UMKM
        try
        {
            if (input == null)
            {
                throw new Exception("UMKM tidak ditemukan");
            }
            int hitung = 0;
            int loop = 0;
            foreach (KategoriBarang kategori in Enum.GetValues(typeof(KategoriBarang)))
            {
                if (InsertBarang.ContainsKey(kategori))
                {
                    foreach (KeyValuePair<string, int> barang in InsertBarang[kategori])
                    {
                        hitung++;
                    }
                }
            }
            foreach (var m in input)
            {
                if (m != null)
                {
                    Console.WriteLine("Nama UMKM: " + m.nama);
                    Console.WriteLine("Jumlah Barang: " + hitung);

                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Method selesai");
        }
    }
    public void HapusBarang()
    {
        try
        {
            Console.WriteLine("Masukkan nama barang:");
            string namaBarang = Console.ReadLine();
            Console.WriteLine("Masukkan kategori barang (Makanan, Minuman, Misc):");
            string kategoriString = Console.ReadLine();
            KategoriBarang kategori;
            if (!Enum.TryParse(kategoriString, true, out kategori))
            {
                throw new Exception("Kategori barang tidak valid.");
            }
            if (InsertBarang.ContainsKey(kategori) && InsertBarang[kategori].ContainsKey(namaBarang))
            {
                InsertBarang[kategori].Remove(namaBarang);
                Console.WriteLine("Barang berhasil dihapus.");
            }
            else
            {
                throw new Exception("Barang tidak ditemukan pada kategori tersebut.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }   
    }
}
