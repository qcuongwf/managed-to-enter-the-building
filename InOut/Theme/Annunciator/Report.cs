using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace Theme.Annunciator
{
    public partial class Report : Form
    {
        public Report(int month)
        {
            InitializeComponent();
            myMonth = month;
        }
        int myMonth = 0;
        private void Report_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            Annunciator.ReportTraffic rp = new Annunciator.ReportTraffic();
            ParameterValues a1 = new ParameterValues();
            ParameterDiscreteValue b1 = new ParameterDiscreteValue();
            b1.Value = myMonth;
            a1.Add(b1);
            rp.DataDefinition.ParameterFields["@mounth"].ApplyCurrentValues(a1);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
