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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string idUser;
        string accID="";
        Process.Users user;
        void LoadInfo()
        {
            ConnectSql connect = new ConnectSql();
            //Load thông tin trạng thái thẻ
            DataTable data = new DataTable();
            data = connect.getDataTable("select CARD_ID from CARDS where CARD_STATUS='CSD' AND CARD_TYPE='nhanvien'");
            cmbNewCard.DataSource = data;
            cmbNewCard.DisplayMember = "CARD_ID";
            cmbNewCard.ValueMember = "CARD_ID";
            if (data.Rows.Count == 0)
            {
                DialogResult dia = new System.Windows.Forms.DialogResult();
                dia = MessageBox.Show("Hiện thẻ chưa sử dụng đã hết\n Bạn có muốn nhập thêm thẻ không?", "Hết thẻ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dia == DialogResult.Yes)
                {
                    frmNhapThe frm = new frmNhapThe();
                    frm.ShowDialog(this);
                    LoadInfo();
                }
            }

            //Load thong tin account
            DataTable dt = connect.getDataTable("SELECT ACCOUNT_USERS_ID,ACCOUNT_CARD_ID FROM ACCOUNTS WHERE ACCOUNT_USERS_ID='" + frmFind.id_users + "'");
            dataGridView1.DataSource = dt;

            if(dataGridView1.RowCount>0) 
            {
                txtCardOld.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                accID = dataGridView1.Rows[0].Cells[0].Value.ToString();
                txtCardOld.Enabled = false;
            }
            //Load thong tin ve user
            idUser = frmFind.id_users;
            txtID.Text = idUser;
            txtID.Enabled = false;//vô hiệu textbox txtIDCard
            this.user = new Users();
            user.LoadUserFromID(idUser);
            txtName.Text = user.name;
            txtPhone.Text = user.phone;
            txtAddress.Text = user.address;
            txtIndentity.Text = user.indentity;
            txtEmail.Text = user.email;
        }
        private void frmReissuedCard_Load(object sender, EventArgs e)
        {
            LoadInfo();            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCardOld.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            accID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnReissued_Click(object sender, EventArgs e)
        {
            Accounts acc = new Accounts(accID, frmFind.id_users, cmbNewCard.SelectedValue.ToString(), "");
            Cards card = new Cards(cmbNewCard.SelectedValue.ToString(), "DSD");
            if (accID != "")
            {
                acc.Add();
                card.Update();
                
            }
            LoadInfo();
        }
    }
}
