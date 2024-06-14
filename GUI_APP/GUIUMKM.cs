using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_APP
{
    public partial class GUIUMKM : Form
    {
        FlowLayoutPanel flowLayoutPanel;
        Panel phanel = new Panel();
        List<BarangUMKM> listUMKM = new List<BarangUMKM>();
        public GUIUMKM()
        {
            InitializeComponent();


            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AutoSize = true;
            this.Controls.Add(flowLayoutPanel);
            phanel.Size = new Size(this.Width,this.Height);
            phanel.AutoScroll = false;
            phanel.BackColor = Color.GreenYellow;
            phanel.Visible = true;
            flowLayoutPanel.Controls.Add(phanel);

            panelAtasUMKM();
            barangUMKM();
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
            foreach (var umkm in listUMKM)
            {
                foreach (var barang in umkm.listBarang)
                {
                    // Bikin Panel
                    Panel panel = new Panel();
                    panel.Size = new System.Drawing.Size(500, 100);
                    panel.Location = new System.Drawing.Point(10, 40 + (110 * i));
                    panel.BackColor = System.Drawing.Color.WhiteSmoke;

                    // bikin button
                    Button button = new Button();
                    button.Text = $"ADD";
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

                    int buttonIndex = i + 1;
                    button.Click += (sender, e) =>
                    {
                        if (barang.stok > 0)
                        {
                            MessageBox.Show($"{label.Text} Berhasil dimasukan ke keranjang!");
                            DataKeranjang.tambahkeKeranjang(barang.namabarang, barang.harga);
                            barang.stok = barang.stok - 1;
                            stoklabel.Text = "Stok : " + barang.stok;
                        }
                        else
                        {
                            MessageBox.Show("Barang sudah habis");
                        }

                    };
                    i++;
                }
            }
        }
    }
}
