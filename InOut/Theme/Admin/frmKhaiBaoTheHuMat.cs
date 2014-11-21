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

        void GetData(int node)
        {
            ConnectSql connect = new ConnectSql();
            if (node == 1)
            {
                DataTable dt = connect.getDataTable("select * from USERS where USERS_ID=" + frmFind.id_users);
                DataRow dtrow = dt.Rows[0];
                txtID.Text = dtrow[2].ToString();
                txtIdentity.Text = dtrow[3].ToString();
                txtIDCard.Text = frmFind.id_users;
            }
            else
            {
                DataTable dt = connect.getDataTable("SELECT CARD_STATUS_ID,CARD_STATUS_NAME from CARD_STATUS");
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "CARD_STATUS_NAME";
                comboBox1.ValueMember = "CARD_STATUS_ID";
            }
        }

        private void frmKhaiBaoTheHuMat_Load(object sender, EventArgs e)
        {
            GetData(1);
            GetData(2);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
