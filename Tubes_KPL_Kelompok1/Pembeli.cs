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
        Dictionary<Buyer, UMKM.namaBarang> keranjang = new Dictionary<Buyer, UMKM.namaBarang>()
        {
            {Buyer.Haikal, UMKM.namaBarang.SodaGembira }
        };

        Dictionary<Buyer, Dictionary<UMKM.namaBarang, int>> qty = new Dictionary<Buyer, Dictionary<UMKM.namaBarang, int>>()
        {
            {Buyer.Haikal, new Dictionary<UMKM.namaBarang, int>
            {
                {UMKM.namaBarang.SodaGembira, 10 }
            } }
        };

        public void Printkeranjang()
        {

            foreach (Buyer pembeli in Enum.GetValues(typeof(Buyer)))
            {
                Console.Write(pembeli.ToString());

                if (qty.ContainsKey(pembeli))
                {
                    foreach (UMKM.namaBarang barang in Enum.GetValues(typeof(UMKM.namaBarang)))
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
    
    public void tambahqty()
    {
        Buyer buyer;
        UMKM.namaBarang barang;
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
