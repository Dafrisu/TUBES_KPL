using System.Runtime.InteropServices.Marshalling;

namespace Keranjang
{
    public class KeranjangPembeli()
    {
        public bool SearchKeranjang(Dictionary<String, int> keranjang, String nama_barang)
        {
            if (KeranjangIsNull(keranjang))
            {
                return keranjang.ContainsKey(nama_barang);
            }
            else
            {
                return false;
            }
        }
        public bool KeranjangIsNull(Dictionary<String, int> keranjang)
        {
            bool kosong = false;
            if (keranjang != null)
            {
                kosong = true;
                return kosong;
            }
            else
            {
                return kosong;
            }
        }
        public void EditKeranjang(Dictionary<String, int> keranjang, String nama_barang, int Kurang)
        {
            try
            {
                if (KeranjangIsNull(keranjang) && SearchKeranjang(keranjang, nama_barang))
                { 
                    keranjang[nama_barang] = Kurang;
                } 
                else
                {
                    throw new Exception("Tidak ada" + nama_barang + "di keranjang");
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteInKeranjang(Dictionary<String, int> keranjang, String nama_barang)
        {
            try 
            {
                if (KeranjangIsNull(keranjang) && SearchKeranjang(keranjang, nama_barang))
                {
                    keranjang.Remove(nama_barang);
                }
                else
                {
                    throw new Exception("Tidak ada" + nama_barang + "di keranjang");
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ClearKeranjang(Dictionary<String, int> keranjang)
        {
            try
            {
                if (KeranjangIsNull(keranjang))
                {
                    keranjang.Clear();
                }
                else
                {
                    throw new Exception("Keranjang kosong");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /*public void AddKeranjang(Dictionary<String, int> keranjang, String nama_barang, int jumlah)
        {
            try
            {
                Console.WriteLine("Masukan Nama Barang: ");
                String namabarang = Console.ReadLine();

                Console.WriteLine("Masukan Jumlah Barang: ");
                int qty = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                if (keranjang.ContainsKey(nama_barang))
                {

                }
                Console.WriteLine(e.Message);
            }
        }*/
    }
}
