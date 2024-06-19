namespace GUI_APP
{
    public partial class GUILogin : Form
    {
        public static String tipe = "";
        public static String username = "";
        public GUILogin()
        {
            InitializeComponent();
            
        }

        private void radioUMKM_CheckedChanged(object sender, EventArgs e)
        {
            tipe = radioUMKM.Text;
        }

        private void radioPembeli_CheckedChanged(object sender, EventArgs e)
        {
            tipe = radioPembeli.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // doin nothin
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            // boolean untuk mengecek apakah akun ada atau tidak
            bool cekCredentials = Akun.CekLogin(fieldUser.Text, FieldPass.Text, tipe);
            if (!cekCredentials)
            {
                MessageBox.Show("Gagal Masuk");
            }
            else
            {
                MessageBox.Show("Berhasil Masuk");
                try
                {
                    if (tipe.Equals("Pembeli"))
                    {
                        username = fieldUser.Text;
                        GUIPembeli guipembeli = new GUIPembeli();
                        this.Visible = false;
                        guipembeli.Show();
                    }
                    else if (tipe.Equals("UMKM"))
                    {
                        username = fieldUser.Text;
                        GUIUMKM guipembeli = new GUIUMKM();
                        this.Visible = false;
                        guipembeli.Show();
                    }
                    else
                    {
                        throw new Exception("Gagal Membaca User");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void GUILogin_Load(object sender, EventArgs e)
        {

        }
    }
}
