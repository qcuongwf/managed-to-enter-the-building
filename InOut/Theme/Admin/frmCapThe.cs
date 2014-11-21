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
    public partial class frmCapThe : Form
    {
        public frmCapThe()
        {
            InitializeComponent();
        }

        Accounts account;
        Users user;
        Cards card;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// XỬ LÝ TRƯỜNG HỢP TÀI KHOẢN HOẶC NGƯỜI DÙNG CÓ SẴN
        /// </summary>

        
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {//CẦN TẠO CODE TỰ DỘNG TẠO ID USER ACCOUNT, TÙY BIẾN LẠI PHẦN THẺ
                user = new Users(txtID.Text, "NHANVIEN", txtName.Text, txtIndentity.Text, txtAddress.Text, txtPhone.Text, "");
                user.AddUser();
                account = new Accounts(txtID.Text, txtID.Text,cmbCard.Text, "");
                account.Add();
                card = new Cards(cmbCard.Text, "DSD");
                card.Update();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
        }
        ConnectSql connect = new ConnectSql();
        DataTable data;
        private void frmCapThe_Load(object sender, EventArgs e)
        {
            data = connect.getDataTable("select CARD_ID from CARDS where CARD_STATUS='CSD'");
            cmbCard.DataSource = data;
            cmbCard.DisplayMember = "CARD_ID";
            cmbCard.ValueMember = "CARD_ID";
        }
    }
}
