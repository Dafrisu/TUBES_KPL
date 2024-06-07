using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_APP
{
    internal class Akun
    {
        static Dictionary<string, Dictionary<String, String>> credentials = new Dictionary<string, Dictionary<String, String>>() {
            {"Haikal", new Dictionary<string, string>(){{ "Gantenk123", "Pembeli" }}},
            {"Darryl", new Dictionary<string, string>(){{ "GantenkBanged", "UMKM" }}}
        };

        public static bool CekLogin(String username, String password, String tipeUser)
        {
            bool cek = false;
            foreach (var akun in credentials)
            {
                if (username.Equals(akun.Key))
                {
                    var user = credentials[akun.Key];
                    foreach (var passTipe in user)
                    {
                        if (password.Equals(passTipe.Key) && tipeUser.Equals(passTipe.Value))
                        {
                            cek = true;
                        }
                    }
                }
            }
            return cek;
        }
    }
}
