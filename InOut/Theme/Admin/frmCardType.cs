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
    public partial class frmCardType : Form
    {
        public frmCardType()
        {
            InitializeComponent();
        }
        TypeOfCard type;
        private void button1_Click(object sender, EventArgs e)
        {
            type = new TypeOfCard(txtID.Text, txtName.Text);
            try { type.Add(); this.Close(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}