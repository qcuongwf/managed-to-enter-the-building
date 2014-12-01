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
    public partial class frmReissuedCard : Form
    {
        public frmReissuedCard()
        {
            InitializeComponent();
        }
        string AccountId;
        void GetData(int node)
        {
            ConnectSql connect = new ConnectSql();
            if (node == 1)
            {
                //lấy dữ liệu từ database bảng USERS và ACCOUNT đổ về Datatable
                DataTable dt = connect.getDataTable("SELECT USERS_ID,USERS_NAME,USERS_IDENTITY,USERS_ADDRESS,USERS_PHONE,USERS_EMAIL FROM USERS WHERE USERS_ID='" + frmFind.id_users+"'");
                //đỗ dữ liệu từ DataTable dt sang DataRow dtrow
                DataRow dtrow = dt.Rows[0];
                //gán dl từ dtrow vào từng textbox
                txtIDUser.Text = dtrow[0].ToString();
                txtName.Text = dtrow[1].ToString();
                txtAddress.Text = dtrow[3].ToString();
                txtPhone.Text = dtrow[4].ToString();
            }
            else
            {
                DataTable dt = connect.getDataTable("SELECT ACCOUNT_ID,ACCOUNT_USERS_ID,ACCOUNT_CARD_ID,ACCOUNT_PASSWORD FROM ACCOUNTS WHERE ACCOUNT_USERS_ID='" + frmFind.id_users+"'");
                dgv_Account.DataSource = dt;
                txtIDCardOld.Text = dgv_Account.Rows[0].Cells[2].Value.ToString();
                AccountId = dgv_Account.Rows[0].Cells[0].Value.ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void frmReissuedCard_Load(object sender, EventArgs e)
        {
            GetData(1);
            GetData(2);
            dgv_Account.ForeColor = Color.Black;
            
            //Load thẻ chưa sử dụng
            ConnectSql connect = new ConnectSql();
            cmbCard.DataSource = connect.getDataTable("select CARD_ID from CARDS where CARD_STATUS='CSD'");
            cmbCard.DisplayMember = "CARD_ID";
            cmbCard.ValueMember = "CARD_ID";

        }

        private void dgv_Account_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtIDCardOld.Text = dgv_Account.Rows[e.RowIndex].Cells[2].Value.ToString();
                AccountId = dgv_Account.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnReissued_Click(object sender, EventArgs e)
        {
            try
            {
                Cards card = new Cards(txtIDCardOld.Text, "CSD");
                card.Update();
                card = new Cards(cmbCard.Text, "DSD");
                card.Update();
                Accounts account = new Accounts(AccountId, cmbCard.Text);
                account.Update();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
