using CrystalDecisions.CrystalReports.Engine;
//using KPRA_RIMS.Forms;
using KPRA_RIMS.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPRA_RIMS
{
    public partial class ReportsForm : MetroFramework.Forms.MetroForm
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void materialDivider1_Click(object sender, EventArgs e)
        {

        }

        public void Urdu()
        {
         
        }

        public void English()
        {
           
        }
     

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        string pid;
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportDocument rd = new KPRA_RIMS.Reports.RPTSale();
            rd.SetParameterValue("dt", "'" + Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd") + "'");
            rd.SetParameterValue("dt1", "'" + Convert.ToDateTime(dateTimePicker2.Text).ToString("yyyy-MM-dd") + "'");
           
            ReportViewer obj = new ReportViewer(rd);
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportDocument rd = new KPRA_RIMS.Reports.ProductWiseSale();
            rd.SetParameterValue("dt", "'" + Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd") + "'");
            rd.SetParameterValue("dt1", "'" + Convert.ToDateTime(dateTimePicker2.Text).ToString("yyyy-MM-dd") + "'");

            ReportViewer obj = new ReportViewer(rd);
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportDocument rd = new KPRA_RIMS.Reports.TaxReport();
            rd.SetParameterValue("dt", "'" + Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd") + "'");
            rd.SetParameterValue("dt1", "'" + Convert.ToDateTime(dateTimePicker2.Text).ToString("yyyy-MM-dd") + "'");

            ReportViewer obj = new ReportViewer(rd);
            obj.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

       

       
    }
}

