using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tubes_KPL_Kelompok1.Pembeli;
using static Tubes_KPL_Kelompok1.UMKM;

namespace Tubes_KPL_Kelompok1
{
    public class Pembeli
    {
        
        public enum Buyer { Haikal, Dafa, Darryl, Fersya, Raphael, Mahesa };

        Dictionary<Buyer, int> id = new Dictionary<Buyer, int>()
        {
            {Buyer.Haikal, 101 },
            {Buyer.Dafa, 102 },
            {Buyer.Darryl, 103 },
            {Buyer.Fersya, 104 },
            {Buyer.Raphael, 105 },
            {Buyer.Mahesa, 106 }
        };
        Dictionary<Buyer, UMKM.NamaBarang> keranjang = new Dictionary<Buyer, UMKM.NamaBarang>()
        {
            {Buyer.Haikal, UMKM.NamaBarang.SodaGembira }
        };

        Dictionary<Buyer, Dictionary<UMKM.NamaBarang, int>> qty = new Dictionary<Buyer, Dictionary<UMKM.NamaBarang, int>>()
        {
            {Buyer.Haikal, new Dictionary<UMKM.NamaBarang, int>
            {
                {UMKM.NamaBarang.SodaGembira, 10 }
            } }
        };

        public void Printkeranjang()
        {

            foreach (Buyer pembeli in Enum.GetValues(typeof(Buyer)))
            {
                Console.Write(pembeli.ToString());

                if (qty.ContainsKey(pembeli))
                {
                    foreach (UMKM.NamaBarang barang in Enum.GetValues(typeof(UMKM.NamaBarang)))
                    {
                        int qtyBarang = qty[pembeli].ContainsKey(barang) ? qty[pembeli][barang] : 0;
                        if (qtyBarang != 0)
                        {
                            Console.Write($" {barang.ToString()}: {qtyBarang},");
                        }
                    }
                }
                else
                {
                    Console.Write(" -,");
                }

                Console.WriteLine();
            }
        }
        public void searchKeranjang()
        {
            Console.WriteLine("Masukan nama barang: ");
            String input = Console.ReadLine();
            bool search = false;

            try
            {
                NamaBarang inputBarang = (NamaBarang)Enum.Parse(typeof(NamaBarang), input);
                foreach (var pair in keranjang)
                {
                    if (pair.Value == inputBarang)
                    {
                        search = true;
                    }
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Input Invalid");
            }
            finally
            {
                if (search)
                {
                    Console.WriteLine("Berikut barangnya");
                }
                else
                {
                    Console.WriteLine("Barang tidak ditemukan");
                }
            }  
        }

        public void tambahqty()
    {
        Buyer buyer;
        UMKM.NamaBarang barang;
        Console.Write("Masukan Nama Buyer: ");
        String input = Console.ReadLine();
            
            if (Enum.TryParse(input, out buyer))
            {
                if (qty.ContainsKey(buyer))
                {
                    Console.WriteLine("Masukan nama Barang: ");
                    input = Console.ReadLine();
                    if (Enum.TryParse(input, out barang))
                    {
                        if (qty[buyer].ContainsKey(barang))
                        {
                            Console.WriteLine("Masukan Kuantitas: ");
                            int masuk = Convert.ToInt32(Console.ReadLine());
                            qty[buyer][barang] = masuk;
                            Console.WriteLine(buyer.ToString() +" " + barang.ToString() + " QTY: " + (qty.ContainsKey(buyer) ? qty[buyer][barang].ToString() : "0"));
                            
                        }
                    }
                    
                }
            }
        }

    }
}
