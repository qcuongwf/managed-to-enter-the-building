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

        //Khởi tạo thông tin kết nối
        ConnectSql connect = new ConnectSql();
        //Khởi tạo thẻ
        Cards cards = new Cards();

        private void frmCardImport_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.cards.LoadStatus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNhapThe frm = new frmNhapThe();
            frm.ShowDialog(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
