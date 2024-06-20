// See https://aka.ms/new-console-template for more information
using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using UMKMconfig;
class Program
{
    static void Main(string[] args)
    {

        TempBarang.setbarang();
        // Tampilkan hasil
        foreach (var barang in TempBarang.baranglist)
        {
            
            Console.WriteLine(barang.Nama);
        }
    }
}
