
﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Tubes_KPL_Kelompok1;
using static Tubes_KPL_Kelompok1.UMKM;

class program
{
    static void Main(string[] args)
    {
        UMKM namabarang = new UMKM("Warteg Bang kal");
        namabarang.TambahStockBarang();
        namabarang.GetBarang();

        Pembeli a = new Pembeli();
        a.tambahqty();
        a.Printkeranjang();

        

    }
}