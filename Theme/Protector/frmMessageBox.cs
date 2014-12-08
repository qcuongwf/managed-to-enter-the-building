using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Theme.Protector
{
    public partial class frmMessageBox : Form
    {
        public frmMessageBox()
        {
            InitializeComponent();
        }
         private int nSecond = 10;
         public frmMessageBox(string strTitle, string strMsg, int second)
        {
            InitializeComponent();
            this.Text = strTitle;
            this.lbMessage.Text = strMsg;
            this.nSecond = second;
            timer1.Enabled = true;
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = nSecond.ToString();
            nSecond--;
            if (nSecond == 0)
                this.Close();
        }
    }
}
