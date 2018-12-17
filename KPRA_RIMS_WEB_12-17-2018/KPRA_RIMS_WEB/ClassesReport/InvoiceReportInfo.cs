namespace KPRA_RIMS_WEB.ClassesReport
{
    using KPRA_RIMS_WEB.Datasets;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Configuration;

    public class InvoiceReportInfo
    {
        private static string connStaticString = WebConfigurationManager.ConnectionStrings["KPRAConnectionString"].ConnectionString;
        private string connString = WebConfigurationManager.ConnectionStrings["KPRAConnectionString"].ConnectionString;

        private DataSetInvoice GetInvoiceByBusiness(string query, string businessName)
        {
            DataSetInvoice invoice2;
            SqlCommand command = new SqlCommand(query) {
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

        public DataSetInvoice GetInvoiceDailySalesBusinessName(string query, string businessName, DateTime today)
        {
            DataSetInvoice invoice2;
            SqlCommand command = new SqlCommand(query) {
                CommandType = CommandType.StoredProcedure
            };
            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    command.Connection = connection;
                    adapter.SelectCommand = command;
                    command.Parameters.AddWithValue("@businessName", businessName);
                    command.Parameters.AddWithValue("@today", today);
                    using (DataSetInvoice invoice = new DataSetInvoice())
                    {
                        adapter.Fill(invoice, "tbl_sales_details");
                        invoice2 = invoice;
                    }
                }
            }
            return invoice2;
        }
    }
}

