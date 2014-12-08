using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Process;

namespace Theme
{
    public partial class FrmChitiet : Form
    {
        public FrmChitiet()
        {
            InitializeComponent();
        }

        Controller.CheckError error = new Controller.CheckError();
        Controller.CheckError checkError = new Controller.CheckError();

        bool isData(TextBox txt, string name)
        {
            if (error.isData(txt.Text)) return true;
            else {
                MessageBox.Show("Bạn chứa nhập " + name, "lỗi");
                txt.Focus();
                return false;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (isData(txtName, "tên khách hàng"))
            {
                Users user = new Users(txtIdcustomer.Text, "KHACH", txtName.Text, txtIndentity.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text);
                user.AddUser();
                Accounts account = new Accounts(txtIdcustomer.Text, txtIdcustomer.Text, cmbCard.SelectedValue.ToString(), "");
                account.Add();
                Cards card = new Cards(cmbCard.SelectedValue.ToString(), cmbStatusCard.SelectedValue.ToString());
                card.Update();
                this.Close();
            }
        }

        private void FrmChitiet_Load(object sender, EventArgs e)
        {
            Users user = new Users();
            ConnectSql myConnect=new ConnectSql();
            if (!user.isExits("KH_")) txtIdcustomer.Text = "KH_001";
            else txtIdcustomer.Text = Controller.Utilities.NextID(myConnect.getLastID("USERS_ID", "USERS", "KH_"), "KH_");
            //Load Thong Tin The
            ConnectSql connect = new ConnectSql();
            cmbCard.DataSource = connect.getDataTable("select CARD_ID from CARDS where CARD_STATUS='CSD' AND CARD_TYPE='khachhang'");         
            cmbCard.DisplayMember = "CARD_ID";
            cmbCard.ValueMember = "CARD_ID";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
