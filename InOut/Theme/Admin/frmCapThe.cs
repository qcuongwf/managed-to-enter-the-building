using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Process;
using Controller;

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
            {
                user = new Users(txtID.Text, "NHANVIEN", txtName.Text, txtIndentity.Text, txtAddress.Text, txtPhone.Text, "");
                user.AddUser();
                account = new Accounts(txtAccountID.Text,txtID.Text,cmbCard.Text,txtPasword.Text);
                account.Add();
                card = new Cards(cmbCard.Text, cmbStatusCard.SelectedValue.ToString());
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
            data = connect.getDataTable("select CARD_ID from CARDS where CARD_STATUS='CSD' AND CARD_TYPE='nhanvien'");
            cmbCard.DataSource = data;
            cmbCard.DisplayMember = "CARD_ID";
            cmbCard.ValueMember = "CARD_ID";
            //Tự động tạo mã account
            txtAccountID.Text = Controller.Utilities.NextID(connect.getLastID("CARD_ID","CARDS"), "NV_");
            //Tự đọng tạo mã user
            txtID.Text = Controller.Utilities.NextID(connect.getLastID("USERS_ID","USERS"), "NV_");
            //Load thông tin trạng thái thẻ
            StatusOfCard statusCard = new StatusOfCard();
            cmbStatusCard.DataSource = statusCard.getDataTableStatusCard();
            cmbStatusCard.DisplayMember = "CARD_STATUS_NAME";
            cmbStatusCard.ValueMember = "CARD_STATUS_ID";
        }
    }
}
