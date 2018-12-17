namespace KPRA_RIMS_WEB.Classes
{
    using KPRA_RIMS_WEB.Datasets;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Configuration;

    public class BusinessReport
    {
        private static string connStaticString = WebConfigurationManager.ConnectionStrings["KPRAConnectionString"].ConnectionString;

        public static DataSetInvoice GetInvoiceDatesAllBusiness(string query, DateTime fromDate, DateTime toDate)
        {
            DataSetInvoice invoice2;
            SqlCommand command = new SqlCommand(query) {
                CommandType = CommandType.StoredProcedure
            };
            using (SqlConnection connection = new SqlConnection(connStaticString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    command.Connection = connection;
                    adapter.SelectCommand = command;
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

        public static DataSetInvoice GetInvoiceDatesAllBusinesses(string query)
        {
            DataSetInvoice invoice2;
            SqlCommand command = new SqlCommand(query) {
                CommandType = CommandType.StoredProcedure
            };
            using (SqlConnection connection = new SqlConnection(connStaticString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    command.Connection = connection;
                    adapter.SelectCommand = command;
                    using (DataSetInvoice invoice = new DataSetInvoice())
                    {
                        adapter.Fill(invoice, "tbl_GetAllTaxesWithTaxRatesofaBusiness");
                        invoice2 = invoice;
                    }
                }
            }
            return invoice2;
        }

        public static DataSetInvoice GetInvoiceDatesAllByTaxRate(string query, DateTime fromDate, DateTime toDate)
        {
            DataSetInvoice invoice2;
            SqlCommand command = new SqlCommand(query) {
                CommandType = CommandType.StoredProcedure
            };
            using (SqlConnection connection = new SqlConnection(connStaticString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    command.Connection = connection;
                    adapter.SelectCommand = command;
                    command.Parameters.AddWithValue("@fromDate", DateTime.Parse(fromDate.ToString("yyyy-MM-dd")));
                    command.Parameters.AddWithValue("@toDate", DateTime.Parse(toDate.ToString("yyyy-MM-dd")));
                    using (DataSetInvoice invoice = new DataSetInvoice())
                    {
                        adapter.Fill(invoice, "tbl_GetAllTaxesTaxRateWise");
                        invoice2 = invoice;
                    }
                }
            }
            return invoice2;
        }
    }
}

