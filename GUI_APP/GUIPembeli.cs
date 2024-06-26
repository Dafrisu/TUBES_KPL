﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GUI_APP
{
    public partial class GUIPembeli : Form
    {
        private List<Panel> panelList;
        private FlowLayoutPanel panelContainer;
        private FlowLayoutPanel layoutKeranjang;
        private TransparentPanel overlayPanel;
        Panel fixedpanel;
        Panel containerPanel;
        Label totalHargaLabel;

        public GUIPembeli()
        {
            InitializeComponent();

            totalHargaLabel = new Label();

            containerPanel = new Panel();
            containerPanel.Dock = DockStyle.None;
            containerPanel.Size = new Size(this.Width - 20, this.Height - 30);
            containerPanel.AutoScroll = false; // Izinkan pengguliran
            this.Controls.Add(containerPanel);

            initpanelLayout();
            overlayPanel = new TransparentPanel();
            overlayPanel.Size = this.ClientSize;
            overlayPanel.Location = new Point(0, 0);
            overlayPanel.Visible = false;
            this.Controls.Add(overlayPanel);
            this.Controls.SetChildIndex(overlayPanel, 0); // Pastikan overlay panel berada di paling atas

            initpanelLogout();
        }

        // method untuk menginisialisasi panelLayout yang menampung panel lainnya
        private void initpanelLayout()
        {
            // Buat FlowLayoutPanel sebagai kontainer untuk panel-panel
            panelContainer = new FlowLayoutPanel();
            panelContainer.Dock = DockStyle.None;
            panelContainer.Size = new Size(containerPanel.Width, containerPanel.Height - 20);
            panelContainer.AutoScroll = true; // Izinkan kontainer untuk melakukan scroll jika diperlukan
            containerPanel.Controls.Add(panelContainer);

            // menampilkan panel menu, yang berada di atas aplikasi, yang berisi keranjang, profil dll
            panelMenu();

            // Menambahkan panel yang berisi barang barang dari UMKM
            AddPanels();
        }
        private void initpanelLogout()
        {
            //menambahkan panel logout
            Panel logoutpanel = new Panel();
            logoutpanel.Size = new Size(300, 250);
            CenterPanel(logoutpanel);
            logoutpanel.BackColor = Color.White;
            

            Label textLogout = new Label();
            textLogout.Text = "Apakah Anda Yakin Ingin Logout?";
            textLogout.Location = new Point(25, 75) ;
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

        private void panelMenu()
        {
            Panel panelAtas = new Panel();
            panelAtas.Size = new System.Drawing.Size(760, 70);
            panelAtas.BackColor = System.Drawing.Color.GreenYellow;

            Label userLabel = new Label();
            userLabel.Text =  GUILogin.username;
            userLabel.Font = new Font("Arial", 8, FontStyle.Regular);
            userLabel.Size = new System.Drawing.Size(250, 30);
            userLabel.Location = new System.Drawing.Point(50, 30);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(32, 32); // Ukuran ikon
            pictureBox.Location = new Point(10, 20); // Posisi ikon dalam panel
            pictureBox.Image = Properties.Resources.profilePic; // Akses ikon dari resource
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            PictureBox keranjang = new PictureBox();
            keranjang.Size = new Size(40, 40);
            keranjang.Location = new Point(660, 20);
            keranjang.Image = Properties.Resources.Keranjangicon;
            keranjang.SizeMode = PictureBoxSizeMode.StretchImage;
            keranjang.Click += (Sender, e) =>
            {
                panelContainer.Visible = false;
                KeranjangPembeli();
                interfaceKeranjang();
                layoutKeranjang.Visible = true;
            };

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
            panelAtas.Controls.Add(keranjang);
            panelAtas.Controls.Add(pictureBox);
            panelAtas.Controls.Add(userLabel);
            panelContainer.Controls.Add(panelAtas);
        }

        // layout keranjang pembeli, plus panel atas/menu
        private void KeranjangPembeli()
        {
            layoutKeranjang = new FlowLayoutPanel();
            layoutKeranjang.Dock = DockStyle.None;
            layoutKeranjang.Size = new Size(containerPanel.Width, containerPanel.Height - 20);
            layoutKeranjang.AutoScroll = true; // Izinkan kontainer untuk melakukan scroll jika diperlukan
            containerPanel.Controls.Add(layoutKeranjang);

            // untuk panel bagian atas
            Panel panelAtas = new Panel();
            panelAtas.Size = new System.Drawing.Size(760, 70);
            panelAtas.BackColor = System.Drawing.Color.GreenYellow;

            Label backLabel = new Label();
            backLabel.Text = "Back";
            backLabel.Size = new System.Drawing.Size(150, 25);
            backLabel.Font = new Font("Arial", 9, FontStyle.Regular);
            backLabel.Location = new System.Drawing.Point(10, 25);
            backLabel.Click += (sender, e) =>
            {
                layoutKeranjang.Visible = false;
                fixedpanel.Visible = false;
                initpanelLayout();
                panelContainer.Visible = true;
            };

            panelAtas.Controls.Add(backLabel);
            layoutKeranjang.Controls.Add(panelAtas);

        }

        // interface keranjang (isi keranjang pembeli)
        private void interfaceKeranjang()
        {
            int totalharga = 0;
            int i = 0;
            foreach (var barang in DataKeranjang.listKeranjang)
            {
                Panel panel = new Panel();
                panel.Size = new System.Drawing.Size(500, 100);
                panel.Location = new System.Drawing.Point(10, 40 + (110 * i));
                panel.BackColor = System.Drawing.Color.Gray;

                // bikin label namabarang
                Label LabelBarang = new Label();
                LabelBarang.Text = barang.namabarang;
                LabelBarang.Size = new System.Drawing.Size(150, 25);
                LabelBarang.Font = new Font("Arial", 9, FontStyle.Regular);
                LabelBarang.Location = new System.Drawing.Point(20, 10);

                // label untuk harga di keranjang
                Label LabelHarga = new Label();
                LabelHarga.Text = "RP." + barang.harga ;
                LabelHarga.Font = new Font("Arial", 9, FontStyle.Regular);
                LabelHarga.Size = new Size(150, 25);
                LabelHarga.Location = new Point(20, 30);

                // label untuk qty di keranjang
                Label Labelqty = new Label();
                Labelqty.Text = "" + barang.qty;
                Labelqty.Size = new Size(50, 25);
                Labelqty.Location = new Point(400, 65);

                // label untuk nama UMKM/penjual
                Label namapenjual = new Label();
                namapenjual.Text = "UMKM: " + barang.namaPenjual;
                namapenjual.Size = new Size(125, 25);
                namapenjual.Location = new Point(200, 50);
                namapenjual.Font = new Font("Arial", 8, FontStyle.Regular);

                // icon untuk + barang
                PictureBox plusitem = new PictureBox();
                plusitem.Size = new Size(25, 25);
                plusitem.Image = Properties.Resources.PlusIcon;
                plusitem.SizeMode = PictureBoxSizeMode.StretchImage;
                plusitem.Location = new Point(435, 65);
                plusitem.Click += (sender, e) =>
                {
                    foreach(var UMKM in Program.listUMKM)
                    {
                        foreach(var barangumkm in UMKM.listBarang)
                        {
                            if (barang.namabarang.Equals(barangumkm.Nama))
                            {
                                if (barangumkm.Stok > 0)
                                {
                                    barangumkm.Stok--;
                                    barang.qty++;
                                    fixedpanel.Controls.Remove(totalHargaLabel);
                                    totalharga = updatetotalharga();
                                    totalHargaLabel.Text = "Total Harga: RP." + totalharga;
                                    fixedpanel.Controls.Add(totalHargaLabel);
                                    Labelqty.Text = "" + barang.qty;
                                }
                                else
                                {
                                    MessageBox.Show("Stok barang habis");
                                }
                            }
                        }
                        
                    }
                };

                // icon untuk - barang
                PictureBox minusitem = new PictureBox();
                minusitem.Size = new Size(25, 25);
                minusitem.Image = Properties.Resources.MinusIcon;
                minusitem.SizeMode = PictureBoxSizeMode.StretchImage;
                minusitem.Location = new Point(365, 65);
                minusitem.Click += (sender, e) =>
                {
                    foreach (var umkm in Program.listUMKM)
                    {
                        foreach (var barangumkm in umkm.listBarang) {
                            if (barang.namabarang.Equals(barangumkm.Nama))
                            {
                                if (barang.qty > 1)
                                {
                                    barangumkm.Stok++;
                                    barang.qty--;
                                    fixedpanel.Controls.Remove(totalHargaLabel);
                                    totalharga = updatetotalharga();
                                    totalHargaLabel.Text = "Total Harga: RP." + totalharga;
                                    fixedpanel.Controls.Add(totalHargaLabel);
                                    Labelqty.Text = "" + barang.qty;
                                }
                                else
                                {
                                    MessageBox.Show("Barang Dihapus");
                                    deletefromKeranjang(barang);
                                    fixedpanel.Controls.Remove(totalHargaLabel);
                                    totalharga = updatetotalharga();
                                    totalHargaLabel.Text = "Total Harga: RP." + totalharga;
                                    fixedpanel.Controls.Add(totalHargaLabel);
                                    layoutKeranjang.Controls.Remove(panel);
                                }
                            }
                        }
                    }
                };

                // icon untuk delete barang
                PictureBox deleteitem = new PictureBox();
                deleteitem.Size = new Size(25, 25);
                deleteitem.Image = Properties.Resources.TrashcanIcon;
                deleteitem.SizeMode = PictureBoxSizeMode.StretchImage;
                deleteitem.Location = new Point(325, 65);
                deleteitem.Click += (sender, e) =>
                {
                    MessageBox.Show("Barang Dihapus");
                    deletefromKeranjang(barang);
                    fixedpanel.Controls.Remove(totalHargaLabel);
                    totalharga = updatetotalharga();
                    totalHargaLabel.Text = "Total Harga: RP." + totalharga;
                    fixedpanel.Controls.Add(totalHargaLabel);
                    layoutKeranjang.Controls.Remove(panel);
                };

                // menambahkan semua icon ke layout
                panel.Controls.Add(namapenjual);
                panel.Controls.Add(plusitem);
                panel.Controls.Add(minusitem);
                panel.Controls.Add(deleteitem);
                panel.Controls.Add(Labelqty);
                panel.Controls.Add(LabelHarga);
                panel.Controls.Add(LabelBarang);
                layoutKeranjang.Controls.Add(panel);
                
            }
            if(DataKeranjang.listKeranjang != null)
            {
                fixedpanel = new Panel();
                fixedpanel.Dock = DockStyle.Bottom;
                fixedpanel.Size = new Size(this.ClientSize.Width, 70); // Contoh ukuran fixedPanel
                fixedpanel.Location = new Point(0, this.ClientSize.Height - fixedpanel.Height); // Contoh penempatan fixedPanel di bagian bawah form
                fixedpanel.BackColor = Color.Gray;
                this.Controls.Add(fixedpanel);
                this.Controls.SetChildIndex(fixedpanel, 0);
                fixedpanel.Visible = true;
            }
            AddBottomPadding();

            totalharga = updatetotalharga();
            totalHargaLabel.Text = "Total Harga: RP." + totalharga;
            totalHargaLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            totalHargaLabel.AutoSize = true;
            totalHargaLabel.Location = new Point(10, 25);

            fixedpanel.Controls.Add(totalHargaLabel);
        }

        public void AddPanels()
        {
            
            panelList = new List<Panel>();
            int i = 0;
            foreach(var umkm in Program.listUMKM)
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

                    // label nama UMKM
                    Label labelUMKM = new Label();
                    labelUMKM.Text = "UMKM: " + umkm.NamaUMKM;
                    labelUMKM.Font = new Font("Arial", 8, FontStyle.Regular);
                    labelUMKM.Size = new System.Drawing.Size(125, 25);
                    labelUMKM.Location = new Point(200, 50);

                    // menambahkan semua attribut diatas ke panel
                    panel.Controls.Add(labelUMKM);
                    panel.Controls.Add(label);
                    panel.Controls.Add(stoklabel);
                    panel.Controls.Add(button);
                    panel.Controls.Add(hargalabel);
                    panelContainer.Controls.Add(panel);

                    panelList.Add(panel);

                    int buttonIndex = i + 1;
                    button.Click += (sender, e) =>
                    {
                        if (barang.Stok > 0)
                        {
                            MessageBox.Show($"{label.Text} Berhasil dimasukan ke keranjang!");
                            DataKeranjang.tambahkeKeranjang(barang.Nama, barang.Harga, umkm.NamaUMKM);
                            barang.Stok = barang.Stok - 1;
                            stoklabel.Text = "Stok : " + barang.Stok;
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

                

        private void deletefromKeranjang(DataKeranjang barang)
        {
            foreach (var umkm in Program.listUMKM)
            {
                foreach (var barangumkm in umkm.listBarang) {
                    if (barang.namabarang.Equals(barangumkm.Nama))
                    {
                        barangumkm.Stok = barangumkm.Stok + barang.qty;
                        DataKeranjang.listKeranjang.Remove(barang);
                    }
                }
                
            }
        }

        // set panel ditengah FORM
        private void CenterPanel(Panel panel)
        {
            int x = (this.ClientSize.Width - panel.Width) / 2;
            int y = (this.ClientSize.Height - panel.Height) / 2;
            panel.Location = new Point(x, y);
        }

        // tambahin padding, somehow pake original padding malah error
        private void AddBottomPadding()
        {
            Panel paddingPanel = new Panel();
            paddingPanel.Size = new Size(layoutKeranjang.ClientSize.Width - 10, 70);
            paddingPanel.BackColor = Color.Transparent; // Warna transparan
            layoutKeranjang.Controls.Add(paddingPanel);
        }

        // cara gweh
        private int updatetotalharga()
        {
            int totalharga = 0;
            foreach(var barang in DataKeranjang.listKeranjang)
            {
                totalharga = totalharga + (barang.harga * barang.qty);
            }
            return totalharga;
        }

        // cara kompleks
        /* 
        private void UpdateTotalHarga()
        {
            int totalharga = DataKeranjang.listKeranjang.Sum(barang => barang.harga * barang.qty);

            foreach (Control control in fixedpanel.Controls)
            {
                if (control is Label label && label.Text.StartsWith("Total Harga"))
                {
                    label.Text = "Total Harga: RP." + totalharga;
                    break;
                }
            }
        }
        */

        private void GUIPembeli_Load(object sender, EventArgs e)
        {

        }
    }

    // Panel transparan khusus
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
}
