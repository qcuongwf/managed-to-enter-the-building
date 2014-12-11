using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace Theme
{
    public partial class frmCardTypeDetail : Form
    {
        public frmCardTypeDetail()
        {
            InitializeComponent();
        }
        ConnectSql connect = new ConnectSql();
        void LoadType()
        {
            dataGridView1.DataSource = connect.getDataTable("select CARD_TYPE_ID as TYPE,CARD_TYPE_NAME as NAME from CARD_TYPES");
        }
        private void frmCardTypeDetail_Load(object sender, EventArgs e)
        {
            LoadType();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCardType frm = new frmCardType();
            frm.ShowDialog(this);
            LoadType();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
