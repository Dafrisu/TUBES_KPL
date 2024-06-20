using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_APP
{
    public class Akun
    {
        static TipeUser user1 = new TipeUser();
        static TipeUser user2 = new TipeUser();
        static TipeUser user3 = new TipeUser();
        public static string tipeUser1;
        public static string tipeUser2;
        public static string tipeUser3;
        static Akun() 
        {
            user1.Pembeli();
            user2.UMKM();
            user3.UMKM();
            tipeUser1 = user1.getCurrentState().ToString();
            tipeUser2 = user2.getCurrentState().ToString();
            tipeUser3 = user3.getCurrentState().ToString();
        }

        

        Dictionary<string, Dictionary<String, String>> credentials = new Dictionary<string, Dictionary<String, String>>() {
            {"Haikal", new Dictionary<string, string>(){{ "Gantenk123", tipeUser1 }}},
            {"Darryl", new Dictionary<string, string>(){{ "GantenkRTX3090", tipeUser2 }}},
            {"Dafa", new Dictionary<string, string>(){{ "Kashep123", tipeUser3 }}}
        };

        public bool CekLogin(String username, String password, String tipeUser)
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
