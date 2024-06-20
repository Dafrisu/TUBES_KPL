using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GUI_APP
{
    public partial class GUIUMKM : Form
    {
        FlowLayoutPanel flowLayoutPanel;
        Panel phanel = new Panel();
        FlowLayoutPanel PanelEditBarang;
        Panel phanelEdit = new Panel();
        List<BarangUMKM> listUMKM = new List<BarangUMKM>();
        BarangUMKM UMKM;
        int TextFieldCount = 1;
        int TextFieldCountAdd = 1;
        Label produkLabel = new Label();
        TextBox textBoxEditStok = new TextBox();
        TextBox textBoxEditHarga = new TextBox();
        TextBox textBoxEditKategori = new TextBox();
        FlowLayoutPanel PanelAddBarang;
        Panel phanelAdd = new Panel();
        Panel overlayPanel = new Panel();

        public GUIUMKM()
        {
            InitializeComponent();
            
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = false;
            flowLayoutPanel.Size = new Size(this.Width-20, this.Height-30);
            this.Controls.Add(flowLayoutPanel);
            phanel.Size = new Size(flowLayoutPanel.Width,flowLayoutPanel.Height);
            phanel.AutoScroll = true;
            phanel.BackColor = Color.GreenYellow;
            flowLayoutPanel.Controls.Add(phanel);

            PanelEditBarang = new FlowLayoutPanel();
            PanelEditBarang.Dock = DockStyle.Fill;
            PanelEditBarang.AutoScroll = true;
            PanelEditBarang.Size = new Size(this.Width, this.Height);
            PanelEditBarang.BackColor = Color.GreenYellow;
            this.Controls.Add(PanelEditBarang);

            phanelEdit.Size = new Size(this.Width, this.Height);
            phanelEdit.AutoScroll = true;
            phanelEdit.BackColor = Color.GreenYellow;
            PanelEditBarang.Controls.Add(phanelEdit);

            textBoxEditStok = IsiPanelEdit("Masukkan Stok Barang");
            textBoxEditHarga = IsiPanelEdit("Masukkan Harga Barang");
            textBoxEditKategori = IsiPanelEdit("Masukkan Kategori Barang");

            phanelEdit.Controls.Add(textBoxEditStok);
            phanelEdit.Controls.Add(textBoxEditHarga);
            phanelEdit.Controls.Add(textBoxEditKategori);
            CreateEditButton();
            HapusButton();

            PanelAddBarang = new FlowLayoutPanel();
            PanelAddBarang.Dock = DockStyle.Fill;
            PanelAddBarang.AutoScroll = true;
            PanelAddBarang.Size = new Size(this.Width, this.Height);
            PanelAddBarang.BackColor = Color.Yellow;
            this.Controls.Add(PanelAddBarang);


            phanelAdd.Size = new Size(this.Width, this.Height);
            phanelAdd.AutoScroll = true;
            phanelAdd.BackColor = Color.GreenYellow;
            phanelAdd.Visible = true;
            PanelAddBarang.Controls.Add(phanelAdd);

            cekUMKM(GUILogin.username);
            addbarangUMKM();
            panelAtasUMKM();
            barangUMKM();
            initpanelLogout();
        }


        public void cekUMKM(String nama)
        {
            foreach (var UMKM in Program.listUMKM)
            {
                if (UMKM.NamaUMKM.Equals(nama))
                {
                    this.UMKM = UMKM;
                    
                }
            }
        }

        
        public void addbarangUMKM()
        {
            Label nama = new Label();
            Label harga = new Label();
            Label stok = new Label();
            Label kategori = new Label();

            nama.Text = "Nama: ";
            harga.Text = "Harga: ";
            stok.Text = "Stok: ";
            kategori.Text = "Kategori: ";

            nama.Location = new Point(150, 70);
            stok.Location = new Point(150, 120);
            harga.Location = new Point(150, 170);
            kategori.Location = new Point(150, 220);
            
            nama.Size = new System.Drawing.Size(100, 25);
            harga.Size = new System.Drawing.Size(100, 25);
            stok.Size = new System.Drawing.Size(100, 25);
            kategori.Size = new System.Drawing.Size(100, 25);

            TextBox textBoxAddNamaBarang = new TextBox();
            TextBox textBoxAddStok = new TextBox();
            TextBox textBoxAddHarga = new TextBox();
            TextBox textBoxAddKategori = new TextBox();

            textBoxAddNamaBarang.Width = 200;
            textBoxAddStok.Width = 200;
            textBoxAddHarga.Width = 200;
            textBoxAddKategori.Width = 200;

            textBoxAddNamaBarang.Location = new Point(250, 70);
            textBoxAddStok.Location = new Point(250, 120);
            textBoxAddHarga.Location = new Point(250, 170);
            textBoxAddKategori.Location = new Point(250, 220);

            phanelAdd.Controls.Add(textBoxAddNamaBarang);
            phanelAdd.Controls.Add(textBoxAddStok);
            phanelAdd.Controls.Add(textBoxAddHarga);
            phanelAdd.Controls.Add(textBoxAddKategori);
            phanelAdd.Controls.Add(nama);
            phanelAdd.Controls.Add(harga);
            phanelAdd.Controls.Add(stok);
            phanelAdd.Controls.Add(kategori);

            Button add = new Button();
            add.Text = $"Tambah Produk";
            add.Size = new System.Drawing.Size(100, 25);
            add.Font = new Font("Arial", 7, FontStyle.Regular);
            add.Location = new System.Drawing.Point(250, 300);
            add.BackColor = Color.White;
            add.Click += (sender, e) =>
            {
                if (!textBoxAddNamaBarang.Text.Equals("") && !textBoxAddStok.Text.Equals("")
                && !textBoxAddHarga.Text.Equals("") && !textBoxAddKategori.Text.Equals(""))
                {
                    string namaBarang = textBoxAddNamaBarang.Text;
                    int stok;
                    int harga;
                    string kategoriBarang = textBoxAddKategori.Text;
                    MessageBox.Show($"Adding Barang: {namaBarang}");

                    if (!int.TryParse(textBoxAddStok.Text, out stok))
                    {
                        MessageBox.Show("Stok harus berupa angka.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Validasi harga
                    if (!int.TryParse(textBoxAddHarga.Text, out harga))
                    {
                        MessageBox.Show("Harga harus berupa angka.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    try
                    {
                        UserManager.Instance.TambahBarangUntukCurrentUser(namaBarang, stok, harga, kategoriBarang);
                        MessageBox.Show("Barang berhasil ditambahkan.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    // Call EditBarang method
                    this.Controls.Remove(flowLayoutPanel);
                    PanelAddBarang.Visible = false;
                    ResetGUI();
                    flowLayoutPanel.Visible = true;
                    textBoxAddNamaBarang.Text = "";
                    textBoxAddStok.Text = "";
                    textBoxAddHarga.Text = "";
                    textBoxAddKategori.Text = "";
                }
                else
                {
                    MessageBox.Show("gagal menambahkan barang, Tidak boleh ada data yang NULL");
                }
            };
            this.phanelAdd.Controls.Add(add);
        }
        private void GUIUMKM_Load(object sender, EventArgs e)
        {

        }

        private void panelAtasUMKM() 
        {
            Panel panelAtas = new Panel();
            panelAtas.Size = new System.Drawing.Size(790, 70);
            panelAtas.BackColor = System.Drawing.Color.White;

            Label userLabel = new Label();
            userLabel.Text = GUILogin.username;
            userLabel.Font = new Font("Arial", 8, FontStyle.Regular);
            userLabel.Size = new System.Drawing.Size(250, 30);
            userLabel.Location = new System.Drawing.Point(50, 30);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(32, 32); // Ukuran ikon
            pictureBox.Location = new Point(15, 20); // Posisi ikon dalam panel
            pictureBox.Image = Properties.Resources.profilePic; // Akses ikon dari resource
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            PictureBox TambahProduk = new PictureBox();
            TambahProduk.Size = new Size(40, 40);
            TambahProduk.Location = new Point(660, 20);
            TambahProduk.Image = Properties.Resources.PlusIcon;
            TambahProduk.SizeMode = PictureBoxSizeMode.StretchImage;

            PictureBox logout = new PictureBox();
            logout.Size = new Size(40, 40);
            logout.Location = new Point(600, 20);
            logout.Image = Properties.Resources.PowerIcon;
            logout.SizeMode = PictureBoxSizeMode.StretchImage;
            logout.Click += (Sender, e) =>
            {
                overlayPanel.Visible = true;
            };

            panelAtas.Controls.Add(logout);
            panelAtas.Controls.Add(TambahProduk);
            panelAtas.Controls.Add(pictureBox);
            panelAtas.Controls.Add(userLabel);
            phanel.Controls.Add(panelAtas);

            TambahProduk.Click += (Sender, e) =>
            {
                MessageBox.Show("Menambahkan Produk");
                flowLayoutPanel.Visible = false;
                PanelEditBarang.Visible = false;
                PanelAddBarang.Visible = true;
            };
        }

        private void barangUMKM() 
        {
            int i = 0;
            foreach (var barang in UMKM.listBarang)
            {
                // Bikin Panel
                Panel panel = new Panel();
                panel.Size = new System.Drawing.Size(500, 100);
                panel.Location = new System.Drawing.Point(10, 40 + (110 * i));
                panel.BackColor = System.Drawing.Color.WhiteSmoke;

                // bikin button
                Button button = new Button();
                button.Text = $"Edit";
                button.Size = new System.Drawing.Size(70, 25);
                button.Font = new Font("Arial", 7, FontStyle.Regular);
                button.Location = new System.Drawing.Point(400, 70);

                // bikin label namabarang
                Label label = new Label();
                label.Text = barang.Nama;
                label.Size = new System.Drawing.Size(150, 25);
                label.Font = new Font("Arial", 9, FontStyle.Regular);
                label.Location = new System.Drawing.Point(40, 30);

                // bikin stok label
                Label stoklabel = new Label();
                stoklabel.Text = "Stok : " + barang.Stok;
                stoklabel.Size = new System.Drawing.Size(150, 25);
                stoklabel.Font = new Font("Arial", 8, FontStyle.Regular);
                stoklabel.Location = new System.Drawing.Point(40, 60);

                // label harga
                Label hargalabel = new Label();
                hargalabel.Text = "Harga : " + barang.Harga;
                hargalabel.Font = new Font("Arial", 8, FontStyle.Regular);
                hargalabel.Size = new System.Drawing.Size(150, 25);
                hargalabel.Location = new System.Drawing.Point(380, 40);

                // menambahkan semua attribut diatas ke panel
                panel.Controls.Add(label);
                panel.Controls.Add(stoklabel);
                panel.Controls.Add(button);
                panel.Controls.Add(hargalabel);
                phanel.Controls.Add(panel);

                int buttonIndex = i + 1;
                button.Click += (sender, e) =>
                {
                    PanelAddBarang.Visible = false;
                    flowLayoutPanel.Visible = false;
                    PanelEditBarang.Visible = true;
                    
                    produkLabel.Font = new Font("Arial", 8, FontStyle.Regular);
                    produkLabel.Size = new System.Drawing.Size(250, 30);
                    produkLabel.Location = new System.Drawing.Point(50, 30);
                    produkLabel.Text = barang.Nama;
                    this.phanelEdit.Controls.Add(produkLabel);
                };
                i++;
            }
        }

        private TextBox IsiPanelEdit(string placeholderText)
        {
            TextBox textBox = new TextBox();
            textBox.Width = 200; 
            textBox.Text = placeholderText; 

            if (TextFieldCount == 1) {
                textBox.Location = new Point(250, 70);
                TextFieldCount++;
            }else if (TextFieldCount == 2)
            {
                textBox.Location = new Point(250,120);
                TextFieldCount++;
            }
            else if (TextFieldCount == 3)
            {
                textBox.Location = new Point(250, 170);
                TextFieldCount++;
            }
            else if (TextFieldCount == 4)
            {
                textBox.Location = new Point(250, 220);
                TextFieldCount++;
            }

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            
            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };

            return textBox;
        }

        //Method dibawah digunakan untuk membuat Edit Button
        public void CreateEditButton() {
            Button button = new Button();
            button.Text = $"Edit";
            button.Size = new System.Drawing.Size(70, 25);
            button.Font = new Font("Arial", 7, FontStyle.Regular);
            button.Location = new System.Drawing.Point(250, 300);
            button.BackColor = Color.White;
            button.Click += (sender, e) =>
            {
                // Debugging output
                string namaBarang = produkLabel.Text;
                int stok = Convert.ToInt32(textBoxEditStok.Text);
                int harga = Convert.ToInt32(textBoxEditHarga.Text);
                string kategoriBarang = textBoxEditKategori.Text;

                MessageBox.Show($"Editing Barang: {namaBarang}, Stok: {stok}, Harga: {harga}, Kategori: {kategoriBarang}");

                // Call EditBarang method
                UserManager.Instance.EditBarangUntukCurrentUser(namaBarang, stok, harga, kategoriBarang);

                MessageBox.Show("Produk Berhasil Diedit");
                this.Controls.Remove(flowLayoutPanel);
                PanelEditBarang.Visible = false;
                PanelAddBarang.Visible = false;
                ResetGUI();
                flowLayoutPanel.Visible = true;
            };
            this.phanelEdit.Controls.Add(button);
        }

        public void HapusButton()
        {
            Button button = new Button();
            button.Text = $"Hapus";
            button.Size = new System.Drawing.Size(180, 25);
            button.Font = new Font("Arial", 7, FontStyle.Regular);
            button.Location = new System.Drawing.Point(400, 300);
            button.BackColor = Color.White;
            button.Click += (sender, e) =>
            {
                // Debugging output
                string namaBarang = produkLabel.Text;

                MessageBox.Show($"Deleting Barang: {namaBarang}");

                // Call EditBarang method
                UMKM.deleteBarang(namaBarang);
                

                MessageBox.Show("Produk Berhasil Dihapus");
                this.Controls.Remove(flowLayoutPanel);
                PanelEditBarang.Visible = false;
                PanelAddBarang.Visible = false;
                ResetGUI();
                flowLayoutPanel.Visible = true;
            };
            this.phanelEdit.Controls.Add(button);
        }

        public void ResetGUI() 
        {
            this.Controls.Remove(flowLayoutPanel);
            
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Size = new Size(this.Width, this.Height);
            this.Controls.Add(flowLayoutPanel);
            flowLayoutPanel.Controls.Remove(phanel);
            phanel = new Panel();
            phanel.Size = new Size(this.Width, this.Height);
            phanel.AutoScroll = true;
            phanel.BackColor = Color.GreenYellow;
            phanel.Visible = true;
            flowLayoutPanel.Controls.Add(phanel);

            panelAtasUMKM();
            barangUMKM();
            
        }
        private void initpanelLogout()
        {
            
            overlayPanel = new TransparentPanel();
            overlayPanel.Size = this.ClientSize;
            overlayPanel.Location = new Point(0, 0);
            overlayPanel.Visible = false;
            this.Controls.Add(overlayPanel);
            this.Controls.SetChildIndex(overlayPanel, 0); // Pastikan overlay panel berada di paling atas
            //menambahkan panel logout
            Panel logoutpanel = new Panel();
            logoutpanel.Size = new Size(300, 250);
            CenterPanel(logoutpanel);
            logoutpanel.BackColor = Color.White;


            Label textLogout = new Label();
            textLogout.Text = "Apakah Anda Yakin Ingin Logout?";
            textLogout.Location = new Point(25, 75);
            textLogout.Size = new Size(250, 25);
            textLogout.Font = new Font("Arial", 8, FontStyle.Regular);


            Button Nobutton = new Button();
            Nobutton.Text = "Tidak";
            Nobutton.Size = new Size(75, 40);
            Nobutton.Location = new Point(165, 125);
            Nobutton.Click += (Sender, e) => overlayPanel.Visible = false;

            Button Yesbutton = new Button();
            Yesbutton.Text = "Ya";
            Yesbutton.Size = new Size(75, 40);
            Yesbutton.Location = new Point(65, 125);
            Yesbutton.Click += (Sender, e) =>
            {
                this.Dispose();
                GUILogin login = new GUILogin();
                login.Visible = true;
            };

            logoutpanel.Controls.Add(textLogout);
            logoutpanel.Controls.Add(Yesbutton);
            logoutpanel.Controls.Add(Nobutton);

            overlayPanel.Controls.Add(logoutpanel);
        }
        private void CenterPanel(Panel panel)
        {
            int x = (this.ClientSize.Width - panel.Width) / 2;
            int y = (this.ClientSize.Height - panel.Height) / 2;
            panel.Location = new Point(x, y);
        }

        public class TransparentPanel : Panel
        {
            public TransparentPanel()
            {
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                this.BackColor = Color.Transparent;
            }

            protected override void OnPaintBackground(PaintEventArgs e)
            {
                base.OnPaint(e);
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 0, 0, 0))) // 50% transparan hitam
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
            }
        }

        public void AddButton() {
            
        }
    }
}
