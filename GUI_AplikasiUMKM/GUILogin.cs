using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_AplikasiUMKM
{
    public partial class GUILogin : Form
    {
        String tipe;
        public GUILogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioPembeli_CheckedChanged(object sender, EventArgs e)
        {
            tipe = radioPembeli.Text;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            bool cekCredentials = LoginCredentials.CekLogin(textBoxUsername.Text, textBoxPassword.Text, tipe);
            if (!cekCredentials)
            {
                MessageBox.Show("Gagal Masuk");
            }
            else 
            {
                MessageBox.Show("Berhasil Masuk");
            }

            if (tipe.Equals("Pembeli") && cekCredentials)
            {
                GUIPembeli guiPembeli = new GUIPembeli();
                guiPembeli.Show();
            }
            else if (tipe.Equals("UMKM") && cekCredentials) 
            { 
                GUIUmkm guiUmkm = new GUIUmkm();
                guiUmkm.Show();
            }
        }

        private void radioUMKM_CheckedChanged(object sender, EventArgs e)
        {
            tipe = radioUMKM.Text;
        }

        private void GUILogin_Load(object sender, EventArgs e)
        {

        }
    }
}
