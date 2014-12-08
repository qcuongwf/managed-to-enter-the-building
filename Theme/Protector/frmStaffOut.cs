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
    public partial class frmStaffOut : Form
    {
        public frmStaffOut()
        {
            InitializeComponent();
        }
        Accounts account;
        Transactions transaction;
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                account = new Accounts();
                string str = account.GetAccountID(txtAddress.Text);
                Cards card = new Cards();
                transaction = new Transactions("", account.GetAccountID(txtAddress.Text), txtAddress.Text, "OUT", "");
                transaction.Insert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        ConnectSql myConnection;
        private void frmStaffOut_Load(object sender, EventArgs e)
        {
           // myConnection = new ConnectSql();
           // DataTable data = new DataTable();
           // data = myConnection.getDataTable("SELECT * FrOM USERS WHERE USERS_IDENTITY LIKE'%" + txtFind.Text + "%' AND USERS_TYPE='NHANVIEN'");
        }
    }
}
