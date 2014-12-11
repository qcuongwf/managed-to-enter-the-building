using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Model;

namespace Theme.Admin
{
    public partial class frmFindIdentity : Form
    {
        public frmFindIdentity()
        {
            InitializeComponent();
        }
        ConnectSql myConnection;
        public static string indentity;
        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            myConnection = new ConnectSql();
            dataGridView.DataSource = myConnection.getDataTable("SELECT * FrOM USERS WHERE USERS_IDENTITY LIKE'%" + txtFind.Text + "%' AND USERS_TYPE='NHANVIEN'");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indentity = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            frmCapThe frm = new frmCapThe();
            frm.ShowDialog(this);
        }
    }
}
