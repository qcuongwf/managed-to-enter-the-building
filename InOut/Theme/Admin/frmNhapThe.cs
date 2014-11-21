using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Process;

namespace Theme
{
    public partial class frmNhapThe : Form
    {
        public frmNhapThe()
        {
            InitializeComponent();
        }
        Cards card;
        private void button1_Click(object sender, EventArgs e)
        {
            card = new Cards(txtIDCard.Text, txtTypeOfCard.Text, txtStatus.Text);
            try
            {
                card.ImportCard();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhapThe_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            txtIDCard.Text = rand.Next().ToString();
        }
    }
}
