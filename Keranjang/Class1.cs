namespace Keranjang
{
    public class KeranjangPembeli()
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
        }
    }
}
