using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_KPL_Kelompok1
{
    public class stateAplikasi
    {
        public enum AppsState
        {
            FiturUMKM,
            FiturPembeli,
            FiturAdmin,
            Netral
            
        }
        private AppsState currentState;

        public stateAplikasi()
        {
            currentState = AppsState.Netral;
            
        }

        public void FiturUMKM()
        {
            currentState = AppsState.FiturUMKM;
            Console.WriteLine("Aplikasi Dalam state UMKM");
        }
        public void FiturPembeli()
        {
            currentState = AppsState.FiturPembeli;
            Console.WriteLine("Aplikasi Dalam state Pembeli");
        }
        public void FiturAdmin()
        {
            currentState = AppsState.FiturAdmin;
            Console.WriteLine("Aplikasi Dalam state Admin");
        }
        public AppsState getCurrentState()
        {
            return this.currentState;
        }
    }
}
