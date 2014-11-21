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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNhapThe_Click(object sender, EventArgs e)
        {
            frmNhapThe frm = new frmNhapThe();
            frm.ShowDialog(this);
        }

        private void btnTypeCard_Click(object sender, EventArgs e)
        {
            frmCardTypeDetail frm = new frmCardTypeDetail();
            frm.ShowDialog(this);
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            frmCardStatusDetail frm = new frmCardStatusDetail();
            frm.Show(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmCapThe frm = new frmCapThe();
            frm.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           frmFind frm = new frmFind();
           frmFind.node = 1;
           frm.ShowDialog(this);
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            frmFind frm = new frmFind();
            frmFind.node = 2;
            frm.ShowDialog(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmFind frm = new frmFind();
            frmFind.node = 3;
            frm.ShowDialog(this);
        }
    }
}
