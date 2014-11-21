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
    public partial class frmCardStatusDetail : Form
    {
        public frmCardStatusDetail()
        {
            InitializeComponent();
        }
        ConnectSql connect = new ConnectSql();
        void LoadStatus()
        {
            dataGridView1.DataSource = connect.getDataTable("select CARD_STATUS_ID as ID,CARD_STATUS_NAME as NAME from CARD_STATUS");
        }
        private void frmStatusDetail_Load(object sender, EventArgs e)
        {
            LoadStatus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCardStatus frm = new frmCardStatus();
            frm.ShowDialog(this);
            LoadStatus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
