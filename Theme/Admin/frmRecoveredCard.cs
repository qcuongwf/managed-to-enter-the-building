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
    public partial class frmRecoveredCard : Form
    {
        public frmRecoveredCard()
        {
            InitializeComponent();
        }
        Users user;
        void GetData(int node)
        {
            ConnectSql connect = new ConnectSql();
            if (node == 1)
            {
                this.user = new Users();
                user.LoadUserFromID(frmFind.id_users);
                txtUser.Text = user.id;
                txtName.Text = user.name;
                txtPhone.Text = user.phone;
                txtAddress.Text = user.address;
            }
            else
            {
                DataTable dt = connect.getDataTable("SELECT ACCOUNT_USERS_ID,ACCOUNT_CARD_ID FROM ACCOUNTS WHERE ACCOUNT_USERS_ID='" + frmFind.id_users + "'");
                dataGridView1.DataSource = dt;
            }

        }

        private void frmRecoveredCard_Load(object sender, EventArgs e)
        {
            GetData(1);
            GetData(2);
            txtIDCard.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri=e.RowIndex;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtIDCard.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cards card = new Cards(txtIDCard.Text, "CSD");
            card.Update();
            this.Close();
        }
    }
}
