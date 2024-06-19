namespace GUI_APP
{
    public partial class GUILogin : Form
    {
        public static String tipe = "";
        public static String username = "";
        public Akun akun = new Akun();
        public GUILogin()
        {
            InitializeComponent();
            
        }

        private void radioUMKM_CheckedChanged(object sender, EventArgs e)
        {
            tipe = "UMKM";
        }

        private void radioPembeli_CheckedChanged(object sender, EventArgs e)
        {
            tipe = "Pembeli";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // doin nothin
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            // boolean untuk mengecek apakah akun ada atau tidak
            bool loginSuccess = UserManager.Login(fieldUser.Text);
            bool cekCredentials = akun.CekLogin(fieldUser.Text, FieldPass.Text, tipe);
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
                        guipembeli.Show();
                        this.Hide();
                        guipembeli.FormClosed += (s, args) => this.Close();
                    }
                    else if (tipe.Equals("UMKM"))
                    {
                        username = fieldUser.Text;
                        GUIUMKM guipembeli = new GUIUMKM();
                        this.Hide();
                        guipembeli.Show();
                        guipembeli.FormClosed += (s, args) => this.Close();
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
