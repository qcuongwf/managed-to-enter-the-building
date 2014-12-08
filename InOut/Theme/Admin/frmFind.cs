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
    public partial class frmFind : Form
    {
        public frmFind()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
        }

        public int location;
        public static string id_users=null;
        public static int node=1;
        ConnectSql connect = new ConnectSql();

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = connect.getDataTable("select * from USERS where USERS_NAME like '%"+textBox1.Text+"%'");
        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            location = e.RowIndex;
        }

        public void openForm()
        {
            if (location != -1)
            {
                id_users = dataGridView1.Rows[location].Cells[0].Value.ToString();

                if (node == 1)
                {
                    frmKhaiBaoTheHuMat frm = new frmKhaiBaoTheHuMat();
                    frm.ShowDialog(this);
                }
                else if (node == 2)
                {
                    frmRecoveredCard frm = new frmRecoveredCard();
                    frm.ShowDialog(this);
                }
                else if (node == 3)
                {
                    frmEditEmployee frm = new frmEditEmployee();
                    frm.ShowDialog(this);
                }
                else if (node == 4)
                {
                    frmReissuedCard frm = new frmReissuedCard();
                    frm.ShowDialog(this);
                }
                else
                {
                    frmCapThe frm = new frmCapThe();
                    frm.ShowDialog(this);
                }
                dataGridView1.DataSource = connect.getDataTable("select * from USERS");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            openForm();
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = connect.getDataTable("select * from USERS");
        }
    }
}
