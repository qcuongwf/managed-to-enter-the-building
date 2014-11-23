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

        void GetData(int node)
        {
            ConnectSql connect = new ConnectSql();
            if (node == 1)
            {
                //lấy dữ liệu từ database bảng USERS và ACCOUNT đổ về Datatable
                DataTable dt = connect.getDataTable("SELECT USERS_ID,USERS_NAME,USERS_IDENTITY,USERS_ADDRESS,USERS_PHONE,USERS_EMAILFROM USERS WHERE USERS_ID=" + frmFind.id_users);
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
                DataTable dt = connect.getDataTable("SELECT ACCOUNT_ID,ACCOUNT_USERS_ID,ACCOUNT_CARD_ID,ACCOUNT_PASSWORD FROM ACCOUNTS WHERE ACCOUNT_USERS_ID=" + frmFind.id_users);
                dgv_Account.DataSource = dt;
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
        }
    }
}
