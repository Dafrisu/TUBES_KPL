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
        Panel phanelEdit = new Panel();
        List<BarangUMKM> listUMKM = new List<BarangUMKM>();
        BarangUMKM UMKM;
        FlowLayoutPanel PanelEditBarang;
        int TextFieldCount = 1;
        Label produkLabel = new Label();
        TextBox textBox1 = new TextBox();
        TextBox textBox2 = new TextBox();
        TextBox textBox3 = new TextBox();

        public GUIUMKM()
        {
            InitializeComponent();
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Size = new Size(this.Width, this.Height);
            this.Controls.Add(flowLayoutPanel);
            phanel.Size = new Size(this.Width,this.Height);
            phanel.AutoScroll = true;
            phanel.BackColor = Color.GreenYellow;
            phanel.Visible = true;
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
            phanelEdit.Visible = true;
            PanelEditBarang.Controls.Add(phanelEdit);

            textBox1 = IsiPanelEdit("Masukkan Stok Barang");
            textBox2 = IsiPanelEdit("Masukkan Harga Barang");
            textBox3 = IsiPanelEdit("Masukkan Kategori Barang");

            phanelEdit.Controls.Add(textBox1);
            phanelEdit.Controls.Add(textBox2);
            phanelEdit.Controls.Add(textBox3);
            cekUMKM(GUILogin.username);
            panelAtasUMKM();
            barangUMKM();
            EditButton();
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

            PictureBox OrderanMasuk = new PictureBox();
            OrderanMasuk.Size = new Size(40, 40);
            OrderanMasuk.Location = new Point(660, 20);
            OrderanMasuk.Image = Properties.Resources.OrderIcon;
            OrderanMasuk.SizeMode = PictureBoxSizeMode.StretchImage;

            panelAtas.Controls.Add(OrderanMasuk);
            panelAtas.Controls.Add(pictureBox);
            panelAtas.Controls.Add(userLabel);
            phanel.Controls.Add(panelAtas);
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
                label.Text = barang.namabarang;
                label.Size = new System.Drawing.Size(150, 25);
                label.Font = new Font("Arial", 9, FontStyle.Regular);
                label.Location = new System.Drawing.Point(40, 30);

                // bikin stok label
                Label stoklabel = new Label();
                stoklabel.Text = "Stok : " + barang.stok;
                stoklabel.Size = new System.Drawing.Size(150, 25);
                stoklabel.Font = new Font("Arial", 8, FontStyle.Regular);
                stoklabel.Location = new System.Drawing.Point(40, 60);

                // label harga
                Label hargalabel = new Label();
                hargalabel.Text = "Harga : " + barang.harga;
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
                    flowLayoutPanel.Visible = false;
                    PanelEditBarang.Visible = true;
                    
                    produkLabel.Font = new Font("Arial", 8, FontStyle.Regular);
                    produkLabel.Size = new System.Drawing.Size(250, 30);
                    produkLabel.Location = new System.Drawing.Point(50, 30);
                    produkLabel.Text = barang.namabarang;
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
        public void EditButton() {
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
                int stok = Convert.ToInt32(textBox1.Text);
                int harga = Convert.ToInt32(textBox2.Text);
                string kategoriBarang = textBox3.Text;

                MessageBox.Show($"Editing Barang: {namaBarang}, Stok: {stok}, Harga: {harga}, Kategori: {kategoriBarang}");

                // Call EditBarang method
                UMKM.EditBarang(namaBarang, stok, harga, kategoriBarang);

                MessageBox.Show("Produk Berhasil Diedit");
                this.Controls.Remove(flowLayoutPanel);
                PanelEditBarang.Visible = false;
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
    }
}
