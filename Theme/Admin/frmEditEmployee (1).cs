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
    public partial class frmEditEmployee : Form
    {
        public frmEditEmployee()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ConnectSql connect = new ConnectSql();
        private void frmEditEmployee_Load(object sender, EventArgs e)
        {
            //lấy dữ liệu từ database bảng USERS và ACCOUNT đổ về Datatable
            DataTable dt = connect.getDataTable("SELECT USERS_ID,USERS_NAME,USERS_IDENTITY,USERS_ADDRESS,USERS_PHONE,USERS_EMAIL FROM USERS WHERE USERS_ID='" + frmFind.id_users + "'");
            //đỗ dữ liệu từ DataTable dt sang DataRow dtrow
            DataRow dtrow = dt.Rows[0];
            //gán dl từ dtrow vào từng textbox
            txtUerID.Text = dtrow[0].ToString();
            txtName.Text = dtrow[1].ToString();
            txtIndentity.Text = dtrow[2].ToString();
            txtAddress.Text = dtrow[3].ToString();
            txtPhone.Text = dtrow[4].ToString();
            txtEmail.Text = dtrow[5].ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Users user = new Users(txtUerID.Text, "NHANVIEN", txtName.Text, txtIndentity.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text);
            user.Update();
            this.Close();
        }
    }
}
