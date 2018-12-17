using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace KPRA_RIMS
{
    public partial class ReportViewer : Form
    {
        public ReportViewer(ReportDocument rd)
        {

            InitializeComponent();

            LogOnInfoClass.setLogonInfo(rd);
            crystalReportViewer1.ReportSource = rd;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
