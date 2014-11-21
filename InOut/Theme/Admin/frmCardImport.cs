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
    public partial class frmCardImport : Form
    {
        public frmCardImport()
        {
            InitializeComponent();
        }
        ConnectSql connect = new ConnectSql();
        void LoadCard()
        {
            dataGridView1.DataSource = connect.getDataTable("select CARD_ID as ID, CARD_TYPE as TYPE, CARD_STATUS as STATUS, CARD_DESCRIPTION as DESCRIPTION from CARDS");
        }
        private void frmCardImport_Load(object sender, EventArgs e)
        {
            LoadCard();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNhapThe frm = new frmNhapThe();
            frm.ShowDialog(this);
            LoadCard();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
