using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
