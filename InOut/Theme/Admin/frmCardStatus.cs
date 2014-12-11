using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace Theme
{
    public partial class frmCardStatus : Form
    {
        public frmCardStatus()
        {
            InitializeComponent();
        }
        StatusOfCard Status;
        private void button1_Click(object sender, EventArgs e)
        {
            Status = new StatusOfCard(txtID.Text, txtName.Text);
            try { Status.Add(); }
            catch(Exception ex)
            {
                    MessageBox.Show(ex.ToString());
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
