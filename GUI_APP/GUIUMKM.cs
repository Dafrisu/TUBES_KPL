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
        BarangUMKM UMKM;

        public GUIUMKM()
        {
            InitializeComponent();
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.None;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Size = new Size(this.Width, this.Height);
            this.Controls.Add(flowLayoutPanel);
            Panel phanel = new Panel();
            phanel.AutoScroll = false;
            phanel.BackColor = System.Drawing.Color.Green;
            phanel.Size = new Size(flowLayoutPanel.Width, flowLayoutPanel.Height);
            flowLayoutPanel.Controls.Add(phanel);

            cekUMKM(GUILogin.username);
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
    }
}
