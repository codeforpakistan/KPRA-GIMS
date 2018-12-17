using KPRA_RIMS_WEB.Classes;
using KPRA_RIMS_WEB.Datasets;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPRA_RIMS_WEB.ReportsWeb
{
    public partial class AllBusinessDateReportWeb : System.Web.UI.Page
    {
        private string connString = WebConfigurationManager.ConnectionStrings["KPRAConnectionString"].ConnectionString;
        private static string connStaticString = WebConfigurationManager.ConnectionStrings["KPRAConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.alertDanger.Visible = false;
        }

        protected void btnGetReportBetweenDates_Click(object sender, EventArgs e)
        {
            this.ReportViewerDates.ProcessingMode = ProcessingMode.Local;
            this.ReportViewerDates.LocalReport.ReportPath = base.Server.MapPath("~/Reports/rpt_GetAllTaxesWithTaxRatesofaBusiness.rdlc");
            try
            {
                DataSetInvoice invoice = BusinessReport.GetInvoiceDatesAllBusiness("usp_GetAllTaxesWithTaxRatesofAllBusinessesByDate", DateTime.Parse(this.txtFromDate.Text.ToString()), DateTime.Parse(this.txtToDate.Text.ToString()));
                if (invoice.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource item = new ReportDataSource("DataSetInvoice", invoice.Tables[0]);
                    this.ReportViewerDates.LocalReport.DataSources.Clear();
                    this.ReportViewerDates.LocalReport.DataSources.Add(item);
                }
                else
                {
                    ReportDataSource item = new ReportDataSource("DataSetInvoice", invoice.Tables[0]);
                    this.ReportViewerDates.LocalReport.DataSources.Clear();
                    this.ReportViewerDates.LocalReport.DataSources.Add(item);
                    this.alertDanger.Visible = true;
                    this.lblDanger.Text = "No Report Content!";
                }
            }
            catch (Exception exception)
            {
                this.lblDanger.Text = exception.Message.ToString();
            }
        }
    }
}