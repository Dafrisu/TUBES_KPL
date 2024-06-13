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

        public GUIUMKM()
        {
            InitializeComponent();
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.None;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AutoSize = true;
            this.Controls.Add(flowLayoutPanel);
            Panel phanel = new Panel();
            phanel.Dock = DockStyle.Fill;
            phanel.AutoScroll = false;
            phanel.BackColor = Color.Brown;
            phanel.Visible = true;
            flowLayoutPanel.Controls.Add(phanel);
        }

        private void GUIUMKM_Load(object sender, EventArgs e)
        {

        }
    }
}
