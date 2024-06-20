using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_APP
{
    internal class UserManager
    {
        private static readonly UserManager instance = new UserManager();
        public static BarangUMKM CurrentUser { get; private set; }
        public static UserManager Instance
        {
            get
            {
                return instance;
            }
        }

        public bool Login(string username)
        {
            // Cari UMKM berdasarkan username yang diberikan
            var user = Program.listUMKM.FirstOrDefault(u => u.NamaUMKM.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                CurrentUser = user;
                return true;
            }
            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public bool IsLoggedIn()
        {
            return CurrentUser != null;
        }

        public void TambahBarangUntukCurrentUser(string namaBarang, int stok, int harga, string kategoriBarang)
        {
            if (CurrentUser != null)
            {
                CurrentUser.TambahBarang(namaBarang, stok, harga, kategoriBarang);
            }
            else
            {
                throw new InvalidOperationException("No user is currently logged in.");
            }
        }

        public void EditBarangUntukCurrentUser(string namaBarang, int stok, int harga, string kategoriBarang)
        {
            if (CurrentUser != null)
            {
                CurrentUser.EditBarang(namaBarang, stok, harga, kategoriBarang);
            }
            else
            {
                throw new InvalidOperationException("No user is currently logged in.");
            }
        }
    }
}
