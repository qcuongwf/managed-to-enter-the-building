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
        StatusOfCard status = new StatusOfCard();
        private void frmStatusDetail_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.status.getDataTableStatusCard();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCardStatus frm = new frmCardStatus();
            frm.ShowDialog(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
