using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Theme
{
    public partial class FrmBaove : Form
    {
        public FrmBaove()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void IN_Click(object sender, EventArgs e)
        {
            Protector.frmStaffIn frm = new Protector.frmStaffIn();
            frm.ShowDialog(this);
        }

        private void FrmBaove_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Protector.frmStaffOut frm = new Protector.frmStaffOut();
            frm.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
