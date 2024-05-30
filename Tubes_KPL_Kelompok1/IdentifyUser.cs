using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_KPL_Kelompok1
{
    public class IdentifyUser
    {
        public enum UserState 
        { 
            UMKM,
            Pembeli,
            Admin,
            Netral
        }
        private UserState currentState;

        public IdentifyUser() {
            currentState = UserState.Netral;
            Console.WriteLine("Tolong masukkan tipe user anda. (Input Merupakan Pembeli atau UMKM atau Admin)");
        }

        public void UMKM()
        {
            currentState = UserState.UMKM;
            Console.WriteLine("Anda login menggunakan user UMKM");
        }
        public void Pembeli()
        {
            currentState = UserState.Pembeli;
            Console.WriteLine("Anda login menggunakan user Pembeli");
        }
        public void Admin()
        {
            currentState = UserState.Admin;
            Console.WriteLine("Anda login menggunakan user Admin");
        }
        public UserState getCurrentState() {
            return this.currentState;
        }
    }
}
