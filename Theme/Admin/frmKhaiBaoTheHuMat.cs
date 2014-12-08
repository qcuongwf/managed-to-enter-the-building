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
    public partial class frmKhaiBaoTheHuMat : Form
    {
        public frmKhaiBaoTheHuMat()
        {
            InitializeComponent();
        }
        ConnectSql connect = new ConnectSql();
        StatusOfCard statusCard = new StatusOfCard();
        void getCardID()
        {
            DataTable dt = connect.getDataTable("select ACCOUNT_ID,ACCOUNT_CARD_ID from ACCOUNTS where ACCOUNT_USERS_ID='"+frmFind.id_users+"'");
            DataRow dt2 = dt.Rows[0];
            txtIDCard.Text = dt2[1].ToString();
            txtIDCard.Enabled = false;
        }
        void GetData(int node)
        {
            
            if (node == 1)
            {
                DataTable dt = connect.getDataTable("SELECT USERS_ID,USERS_NAME,USERS_IDENTITY,USERS_ADDRESS,USERS_PHONE,USERS_EMAIL FROM USERS WHERE USERS_ID='" + frmFind.id_users + "' ");
                DataRow dtrow = dt.Rows[0];
                txtID.Text = dtrow[0].ToString();
                txtName.Text = dtrow[1].ToString();
                txtIdentity.Text = dtrow[2].ToString();
                txtAddress.Text = dtrow[3].ToString();
            }
            else
            {
                comboBox1.DataSource = statusCard.getDataTableStatusCard();
                comboBox1.DisplayMember = "CARD_STATUS_NAME";
                comboBox1.ValueMember = "CARD_STATUS_ID";
            }
        }

        private void frmKhaiBaoTheHuMat_Load(object sender, EventArgs e)
        {
                GetData(1);
                GetData(2);
                getCardID();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Cards card = new Cards(txtIDCard.Text, comboBox1.SelectedValue.ToString());
                card.Update();
                DialogResult dia = new DialogResult();
                dia = MessageBox.Show("Bạn có muốn cấp lại thẻ cho nhân viên không?","Cap the", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dia == DialogResult.Yes)
                {
                    frmReissuedCard frm = new frmReissuedCard();
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
