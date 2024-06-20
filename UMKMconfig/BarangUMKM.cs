using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMKMconfig
{
    internal class BarangUMKM
    {
        public String NamaUMKM;

        public List<Barang> listBarang = new List<Barang>();

        public BarangUMKM(String nama)
        {
            this.NamaUMKM = nama;
        }
    }
}
