using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Process;

namespace Theme
{
    public partial class Login : Form
    {
        public Login()//hàm login
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';//gán giá trị hiển thị trên textbox bằng dấu *
            txtPassword.MaxLength = txtAccount.MaxLength = 15;//giơi hạn độ dài
        }

        ConnectSql myConnect = new ConnectSql();
        DataTable dtDangNhap = new DataTable();// tạo bảng datatable dtDangNhap
        private SqlDataAdapter dap;

        private void btnExitProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public bool checkexistTen(string sql, TextBox txt, string ms)//hàm kiểm tra tồn tại tên đăng nhập
        {
            //			con.Open();
            bool f = true;
            dap = new SqlDataAdapter(sql, myConnect.getConnection);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            dtDangNhap = ds.Tables[0];
            if (dtDangNhap.Rows.Count == 0)//đếm số dòng trong bảng tạm đăng nhập
            {
                f = false;
                MessageBox.Show(ms, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt.Text = "";
                txt.Focus();
            }
            //			con.Close();

            return f;
        }

        public bool checkexistMK(string sql, TextBox txt, string ms)//hàm kiểm tra tồn tại của password
        {
            //			con.Open();
            bool f = true;
            dap = new SqlDataAdapter(sql, myConnect.getConnection);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            dtDangNhap = ds.Tables[0];
            if (dtDangNhap.Rows.Count == 0)
            {
                f = false;
                MessageBox.Show(ms, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Text = "";
                txtPassword.Focus();
            }
            //			con.Close();
            return f;
        }

        private bool checknulltb(TextBox txt, string ms)//hàm kiểm tra giá trị có bị null k
        {
            bool f = true;
            if ((txt.Text.Length == 0) || (txt.Text.Trim() == ""))
            {
                f = false;
                MessageBox.Show(ms, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt.Text = "";
                txt.Focus();
            }
            return f;
        }

        string type(string stringSQLConnect)
        {
            SqlCommand cmd = new SqlCommand(stringSQLConnect, myConnect.getConnection);
            string count = (string)cmd.ExecuteScalar();
            return count;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string stringLogin = "SELECT ACCOUNT_ID FROM ACCOUNTS WHERE ACCOUNT_ID='" + txtAccount.Text + "'";
            string stringPass = "SELECT ACCOUNT_PASSWORD FROM ACCOUNTS WHERE ( ACCOUNT_ID='" + txtAccount.Text + "' AND ACCOUNT_PASSWORD='" + txtPassword.Text + "')";
            string stringType = "select RTRIM(USERS.USERS_TYPE) from ACCOUNTS acc,USERS where acc.ACCOUNT_ID='"+txtAccount.Text+"' AND acc.ACCOUNT_USERS_ID=users.USERS_ID";
            if (checknulltb(txtAccount, "Tên đăng nhập không được rỗng !"))
            {
                if (checknulltb(txtPassword, "Mật khẩu không được rỗng !"))
                {
                    if (checkexistTen(stringLogin, txtAccount, "Tên đăng nhập này không tồn tại. Bạn phải đăng nhập lại !"))
                    {
                        if (checkexistMK(stringPass, txtPassword, "Bạn đánh sai mật khẩu !"))
                        {
                            string userType = type(stringType);
                            if(userType=="ADMIN")
                            {
                                frmAdmin frm=new frmAdmin();
                                this.Hide();
                                frm.ShowDialog(this);
                                this.Show();

                            }
                            else if(userType=="BV")
                            {
                                FrmBaove frm=new FrmBaove();
                                this.Hide();
                                frm.ShowDialog(this);
                                this.Show();
                            }
                        }
                    }
                }
            }
        }

        private void txtAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//nhấn enter
                txtPassword.Focus();//chuyển con trỏ xuống ô password
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//nhấn enter
                btnLogin.PerformClick();//gọi hàm đăng nhập
        }
    }
}
