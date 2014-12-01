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

        private void btnIn_Click(object sender, EventArgs e)
        {
            Users user = new Users(txtIdcustomer.Text, "NHANVIEN", txtName.Text, txtIndentity.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text);
            user.AddUser();
            Accounts account = new Accounts(txtIdcustomer.Text, txtIdcustomer.Text, txtIdcard.Text, "");
            account.Add();
            Cards card = new Cards(txtIdcard.Text,"CSD");
            card.Update();
        }
    }
}
