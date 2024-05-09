﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tubes_KPL_Kelompok1.UMKM;

namespace Tubes_KPL_Kelompok1
{
    public class Keranjang()
    {
        public string namabarang { get; set; }
        public double Price { get; set; }
        public int qty { get; set; }
        public string namaToko { get; set; }


        public Dictionary<string, List<(string, int)>> keranjang = new Dictionary<string, List<(string, int)>>();
        //Indomaret <Soda gembira, 10>
        public class Manage()
        {
            List<(string, int)> productList = new List<(string, int)>();
            //SodaGembira, 10
            public void AddProduct()
            {
                Console.WriteLine("Masukan Nama Barang: ");
                string namabarang = Console.ReadLine();

                Console.WriteLine("Masukan jumlah pesanan Barang: ");
                int qty = Convert.ToInt32(Console.ReadLine());

                productList.Add((namabarang, qty));
                foreach (var item in productList)
                {
                    Console.WriteLine(item);
                }
            }

            public void check(UMKM[] tit, string nama)
            {
                try
                {
                    for (int i = 0; i < tit.Length; i++)
                    {
                        if (tit[i].nama == nama)
                        {
                            tit[i].GetBarang();
                            tit[i].KurangStock();
                            tit[i].GetBarang();
                        }
                        else if (i == tit.Length)
                        {
                            throw new Exception("bang gaada nama yang kek gitu");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
