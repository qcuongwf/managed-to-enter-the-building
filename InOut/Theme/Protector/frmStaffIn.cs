using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Process;

namespace Theme.Protector
{
    public partial class frmStaffIn : Form
    {
        public frmStaffIn()
        {
            InitializeComponent();
        }

        Transactions transaction;
        Accounts account;
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                account = new Accounts();
                string str = account.GetAccountID(txtAddress.Text);
                Cards card = new Cards();
                switch (card.CardTatus(txtAddress.Text))
                {
                    case "": MessageBox.Show("Thẻ không tồn tại trong hệ thống \nHoặc chưa được khai báo","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                        break;
                    case "CSD": MessageBox.Show("Thẻ " + txtAddress.Text + " chưa khai báo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        break;
                    case "DSD": transaction = new Transactions("", account.GetAccountID(txtAddress.Text), txtAddress.Text, "IN", "");
                    transaction.Insert();
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
