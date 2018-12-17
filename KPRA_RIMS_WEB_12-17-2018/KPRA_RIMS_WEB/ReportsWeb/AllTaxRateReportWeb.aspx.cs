using KPRA_RIMS_WEB.Classes;
using KPRA_RIMS_WEB.Datasets;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPRA_RIMS_WEB.ReportsWeb
{
    public partial class AllTaxRateReportWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.alertDanger.Visible = false;
        }

        protected void btnGetReportsByTaxRatesBetweenDates_Click(object sender, EventArgs e)
        {
            this.ReportViewerTaxRateWise.ProcessingMode = ProcessingMode.Local;
            this.ReportViewerTaxRateWise.LocalReport.ReportPath = base.Server.MapPath("~/Reports/rpt_GetAllTaxesTaxRateWise.rdlc");
            try
            {
                DataSetInvoice invoice = BusinessReport.GetInvoiceDatesAllByTaxRate("usp_GetAllTaxesGroupByTaxRates", DateTime.Parse(this.txtFromDate.Text.ToString()), DateTime.Parse(this.txtToDate.Text.ToString()));
                if (invoice.Tables[1].Rows.Count > 0)
                {
                    ReportDataSource item = new ReportDataSource("DataSetInvoice", invoice.Tables[1]);
                    this.ReportViewerTaxRateWise.LocalReport.DataSources.Clear();
                    this.ReportViewerTaxRateWise.LocalReport.DataSources.Add(item);
                }
                else
                {
                    ReportDataSource item = new ReportDataSource("DataSetInvoice", invoice.Tables[1]);
                    this.ReportViewerTaxRateWise.LocalReport.DataSources.Clear();
                    this.ReportViewerTaxRateWise.LocalReport.DataSources.Add(item);
                    this.alertDanger.Visible = true;
                    this.lblDanger.Text = "No Report Content!";
                }
            }
            catch (Exception exception)
            {
                this.lblDanger.Text = exception.Message;
            }
        }

    }
}