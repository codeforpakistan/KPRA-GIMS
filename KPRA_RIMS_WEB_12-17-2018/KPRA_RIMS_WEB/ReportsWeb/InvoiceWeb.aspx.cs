using KPRA_RIMS_WEB.ClassesReport;
using KPRA_RIMS_WEB.Datasets;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPRA_RIMS_WEB.ReportsWeb
{
    public partial class InvoiceWeb : System.Web.UI.Page
    {
        private string connString = WebConfigurationManager.ConnectionStrings["KPRAConnectionString"].ConnectionString;
        private static string connStaticString = WebConfigurationManager.ConnectionStrings["KPRAConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.alertDanger.Visible = false;
        }
        [WebMethod]
        public static List<string> GetBusinessCode(string businessCode) {
            List<string> businessCodeList = new List<string>();
           businessCodeList= WebMethods.FetchBusinessCodeFromDB(businessCode);
           return businessCodeList.ToList<string>();
        }
            

        [WebMethod]
        public static List<string> GetBusinessName(string businessName) {
            List<string> businessNameList = new List<string>();
           businessNameList= WebMethods.FetchBusinessNameFromDB(businessName);
           return businessNameList;
        }
            
        private DataSetInvoice GetInvoiceByBusiness(string query, string businessName)
        {
            DataSetInvoice invoice2;
            SqlCommand command = new SqlCommand(query)
            {
                CommandType = CommandType.StoredProcedure
            };
            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    command.Connection = connection;
                    adapter.SelectCommand = command;
                    command.Parameters.AddWithValue("@businessName", businessName);
                    using (DataSetInvoice invoice = new DataSetInvoice())
                    {
                        adapter.Fill(invoice, "tbl_invoice_by_business_code");
                        invoice2 = invoice;
                    }
                }
            }
            return invoice2;
        }

        private DataSetInvoice GetInvoiceByBusinessCode(string query, string businessCode)
        {
            DataSetInvoice invoice2;
            SqlCommand command = new SqlCommand(query)
            {
                CommandType = CommandType.StoredProcedure
            };
            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    command.Connection = connection;
                    adapter.SelectCommand = command;
                    command.Parameters.AddWithValue("@businessCode", businessCode);
                    using (DataSetInvoice invoice = new DataSetInvoice())
                    {
                        adapter.Fill(invoice, "tbl_GetAllTaxesWithTaxRatesofaBusiness");
                        invoice2 = invoice;
                    }
                }
            }
            return invoice2;
        }

        private DataSetInvoice GetInvoiceByBusinessID(string query, int businessID)
        {
            DataSetInvoice invoice2;
            SqlCommand command = new SqlCommand(query)
            {
                CommandType = CommandType.StoredProcedure
            };
            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    command.Connection = connection;
                    adapter.SelectCommand = command;
                    command.Parameters.AddWithValue("@businessID", businessID);
                    using (DataSetInvoice invoice = new DataSetInvoice())
                    {
                        adapter.Fill(invoice, "tbl_sales_master");
                        invoice2 = invoice;
                    }
                }
            }
            return invoice2;
        }

        private DataSetInvoice GetInvoiceByBusinessName(string query, string businessName)
        {
            DataSetInvoice invoice2;
            SqlCommand command = new SqlCommand(query)
            {
                CommandType = CommandType.StoredProcedure
            };
            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    command.Connection = connection;
                    adapter.SelectCommand = command;
                    command.Parameters.AddWithValue("@businessName", businessName);
                    using (DataSetInvoice invoice = new DataSetInvoice())
                    {
                        adapter.Fill(invoice, "tbl_GetAllTaxesWithTaxRatesofaBusiness");
                        invoice2 = invoice;
                    }
                }
            }
            return invoice2;
        }

        private DataSetInvoice GetInvoiceByDatesBusinessName(string query, string businessName, DateTime fromDate, DateTime toDate)
        {
            DataSetInvoice invoice2;
            SqlCommand command = new SqlCommand(query)
            {
                CommandType = CommandType.StoredProcedure
            };
            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    command.Connection = connection;
                    adapter.SelectCommand = command;
                    command.Parameters.AddWithValue("@businessName", businessName);
                    command.Parameters.AddWithValue("@fromDate", DateTime.Parse(fromDate.ToString("yyyy-MM-dd")));
                    command.Parameters.AddWithValue("@toDate", DateTime.Parse(toDate.ToString("yyyy-MM-dd")));
                    using (DataSetInvoice invoice = new DataSetInvoice())
                    {
                        adapter.Fill(invoice, "tbl_GetAllTaxesWithTaxRatesofaBusiness");
                        invoice2 = invoice;
                    }
                }
            }
            return invoice2;
        }

        protected void btnBusinessName_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(()=>
            {
                if (this.chkBusinessName.Checked && !this.chkDates.Checked)
                {
                    this.chkBusinessName.Checked = false;
                    this.ReportViewerInvoice.ProcessingMode = ProcessingMode.Local;
                    this.ReportViewerInvoice.LocalReport.ReportPath = base.Server.MapPath("~/Reports/rpt_GetAllTaxesWithTaxRatesofaBusiness.rdlc");
                    DataSetInvoice invoiceByBusinessName = this.GetInvoiceByBusinessName("usp_GetAllTaxesWithTaxRatesofaBusinessByName", this.txtBusinessName.Text.ToString());
                    if (invoiceByBusinessName.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource item = new ReportDataSource("DataSetInvoice", invoiceByBusinessName.Tables[0]);
                        this.ReportViewerInvoice.LocalReport.DataSources.Clear();
                        this.ReportViewerInvoice.LocalReport.DataSources.Add(item);
                    }
                    else
                    {
                        this.alertDanger.Visible = true;
                        this.lblDanger.Text = "No Report Content!";
                        ReportDataSource item = new ReportDataSource("DataSetInvoice", invoiceByBusinessName.Tables[0]);
                        this.ReportViewerInvoice.LocalReport.DataSources.Clear();
                        this.ReportViewerInvoice.LocalReport.DataSources.Add(item);
                    }
                }
                else if (this.chkBusinessCode.Checked)
                {
                    this.chkBusinessCode.Checked = false;
                    this.ReportViewerInvoice.ProcessingMode = ProcessingMode.Local;
                    this.ReportViewerInvoice.LocalReport.ReportPath = base.Server.MapPath("~/Reports/rpt_GetAllTaxesWithTaxRatesofaBusiness.rdlc");
                    DataSetInvoice invoiceByBusinessCode = this.GetInvoiceByBusinessCode("usp_GetAllTaxesWithTaxRatesofaBusiness", this.txtBusinessCode.Text.ToString());
                    if (invoiceByBusinessCode.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource item = new ReportDataSource("DataSetInvoice", invoiceByBusinessCode.Tables[0]);
                        this.ReportViewerInvoice.LocalReport.DataSources.Clear();
                        this.ReportViewerInvoice.LocalReport.DataSources.Add(item);
                    }
                    else
                    {
                        this.alertDanger.Visible = true;
                        this.lblDanger.Text = "No Report Content!";
                        ReportDataSource item = new ReportDataSource("DataSetInvoice", invoiceByBusinessCode.Tables[0]);
                        this.ReportViewerInvoice.LocalReport.DataSources.Clear();
                        this.ReportViewerInvoice.LocalReport.DataSources.Add(item);
                    }
                }
                else if (this.chkDates.Checked && this.chkBusinessName.Checked)
                {
                    this.chkDates.Checked = false;
                    this.chkBusinessName.Checked = false;
                    this.ReportViewerInvoice.ProcessingMode = ProcessingMode.Local;
                    this.ReportViewerInvoice.LocalReport.ReportPath = base.Server.MapPath("~/Reports/rpt_GetAllTaxesWithTaxRatesofaBusiness.rdlc");
                    DataSetInvoice invoice3 = this.GetInvoiceByDatesBusinessName("usp_GetAllTaxesWithTaxRatesofaBusinessByDate", this.txtBusinessName.Text.ToString(), DateTime.Parse(this.txtFromDate.Text.ToString()), DateTime.Parse(this.txtToDate.Text.ToString()));
                    if (invoice3.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource item = new ReportDataSource("DataSetInvoice", invoice3.Tables[0]);
                        this.ReportViewerInvoice.LocalReport.DataSources.Clear();
                        this.ReportViewerInvoice.LocalReport.DataSources.Add(item);
                    }
                    else
                    {
                        this.alertDanger.Visible = true;
                        this.lblDanger.Text = "No Report Content!";
                        ReportDataSource item = new ReportDataSource("DataSetInvoice", invoice3.Tables[0]);
                        this.ReportViewerInvoice.LocalReport.DataSources.Clear();
                        this.ReportViewerInvoice.LocalReport.DataSources.Add(item);
                    }
                }
            });
            thread1.Start();
            thread1.Join();
        }
    }
}