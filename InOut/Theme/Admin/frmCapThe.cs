using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
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
                user = new Users(txtID.Text, "NHANVIEN  ", txtName.Text, txtIndentity.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text);
                user.AddUser();
                account = new Accounts(txtID.Text, txtID.Text, cmbCard.Text,"");
                account.Add();
                card = new Cards(cmbCard.Text, "DSD");
                card.Update();
                LoadInfo();
                delTextbox(); //xoa thong tin da nhap tren textbox
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
            LoadInfo();
        }
        void LoadInfo()
        {
            data = connect.getDataTable("select CARD_ID from CARDS where CARD_STATUS='CSD' AND CARD_TYPE='nhanvien'");
            cmbCard.DataSource = data;
            cmbCard.DisplayMember = "CARD_ID";
            cmbCard.ValueMember = "CARD_ID";
            if (data.Rows.Count == 0)
            {
                DialogResult dia = new System.Windows.Forms.DialogResult();
                dia = MessageBoxCustom.MessageBoxCustom.Show("Hiện thẻ chưa sử dụng đã hết\n Bạn có muốn nhập thêm thẻ không?", "Hết thẻ", MessageBoxCustom.MessageBoxCustom.enumMessageIcon.Question, MessageBoxCustom.MessageBoxCustom.enumMessageButton.YesNo);
                if (dia == DialogResult.Yes)
                {
                    frmNhapThe frm = new frmNhapThe();
                    frm.ShowDialog(this);
                    LoadInfo();
                }
                else this.Close();
            }
            //Tự đọng tạo mã user
            user = new Users();
            txtID.Text = Controller.Utilities.NextID(user.getLastUserID(), "NV_");
            user = new Users();
            dgvListEmploye.DataSource = user.LoadTableUser();
        }
        void delTextbox()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtIndentity.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
        }
    }
}
