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
        Controller.CheckError error = new Controller.CheckError();
        private void button1_Click(object sender, EventArgs e)
        {
            card = new Cards(txtIDCard.Text, cmbTypeOfCard.SelectedValue.ToString(), "CSD");
            try
            {
                timer1.Stop();
                timer1.Interval = 1000;
                timer1.Start();
                if (card.isata(txtIDCard.Text)) lblNotification.Text = "thẻ " + txtIDCard.Text + " đã tồn tại";
                else if (!error.isNumber(txtIDCard.Text)) { lblNotification.Text = "thẻ phải là số"; txtIDCard.Text = ""; txtIDCard.Focus(); }
                else if (!error.OverNubmer(txtIDCard.Text, 10)) { lblNotification.Text = "nhập quá kí tự cho phép"; txtIDCard.Text = ""; txtIDCard.Focus(); }
                else
                {
                    card.ImportCard();
                    lblNotification.Text = "Nhập thẻ " +txtIDCard.Text+ "thành công";
                }
                
                Random rand = new Random();
                txtIDCard.Text = rand.Next().ToString();
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
            TypeOfCard type = new TypeOfCard();
            cmbTypeOfCard.DataSource = type.LoadType();
            cmbTypeOfCard.DisplayMember = "CARD_TYPE_NAME";
            cmbTypeOfCard.ValueMember = "CARD_TYPE_ID";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNotification.Text = "";
        }
    }
}
