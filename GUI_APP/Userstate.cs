using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_APP
{
    internal class Userstate
    {
        public enum AppsState
        {
            FiturUMKM,
            FiturPembeli,
            FiturAdmin,
            Netral

        }
        private AppsState currentState;

        public Userstate()
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
        public void cekUser(String input) 
        {
            if (input.Equals(Convert.ToString(TipeUser.UserState.Pembeli)))
            {
                this.FiturPembeli();
            }
            else if (input.Equals(Convert.ToString(TipeUser.UserState.UMKM)))
            {
                this.FiturUMKM();
            }
            else
            {
                MessageBox.Show("Tipe User tidak valid, Tidak bisa akses fitur");
            }
        }
    }
}

