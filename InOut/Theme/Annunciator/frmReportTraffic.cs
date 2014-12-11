using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace Theme
{
    public partial class frmReportTheHuMat : Form
    {
        public frmReportTheHuMat()
        {
            InitializeComponent();
        }
        Model.Transactions trans = new Model.Transactions();
        private void cmbMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = trans.report(int.Parse(cmbMonth.SelectedItem.ToString()));
            btnReport.Enabled = true;
            if (dataGridView1.RowCount > 1) btnReport.Enabled = true;
            else btnReport.Enabled = false;
        }

        private void frmReportTheHuMat_Load(object sender, EventArgs e)
        {
            btnReport.Enabled = false;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Annunciator.Report frm = new Annunciator.Report(int.Parse(cmbMonth.SelectedItem.ToString()));
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
