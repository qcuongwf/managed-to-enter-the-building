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
        //biên chứa mã số nhân viên
        string idUser = "";
        Users user;

        private void frmEditEmployee_Load(object sender, EventArgs e)
        {
            idUser = frmFind.id_users;
            //gán thông tin nhân viên vào textbox
            txtIDCard.Text = idUser;
            //vô hiệu textbox txtIDCard
            txtIDCard.Enabled = false;
            this.user = new Users();
            user.LoadUserFromID(idUser);
            txtName.Text = user.name;
            txtPhone.Text = user.phone;
            txtAddress.Text = user.address;
            txtIndentity.Text=user.indentity;
            txtEmail.Text=user.email;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
                this.user = new Users(txtIDCard.Text, "NHANVIEN", txtName.Text, txtIndentity.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text);
                user.Update();
                this.Close();
        }
    }
}
