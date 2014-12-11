using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Theme
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Theme.frmReportTheHuMat frm = new frmReportTheHuMat();
            frm.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
