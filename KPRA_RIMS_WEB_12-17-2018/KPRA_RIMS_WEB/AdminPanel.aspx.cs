using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPRA_RIMS_WEB
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        private static string connStaticString = WebConfigurationManager.ConnectionStrings["KPRAConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        [WebMethod]
        public static int GetNumberOfOnlineUsers()
        {
            int numOnlineUsers = 0;
            SqlConnection conn = new SqlConnection(connStaticString);
            SqlCommand cmd = new SqlCommand("sp_NumberofOnlineUsers", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            
            if (cmd.ExecuteScalar() == DBNull.Value)
            {
                numOnlineUsers = 0;
            }
            else
            {
                numOnlineUsers =(int) cmd.ExecuteScalar();
            }
            conn.Close();
            return numOnlineUsers;
        }
     
        [WebMethod]
        public static int GetNumberOfTransactionsToday()
        {
            int numTrxToday = 0;
            SqlConnection conn = new SqlConnection(connStaticString);
            SqlCommand cmd = new SqlCommand("sp_NumberOfTransactionsToday", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            if (cmd.ExecuteScalar() == DBNull.Value)
            {
                numTrxToday = 0;
            }
            else
            {
                numTrxToday = (int)cmd.ExecuteScalar();
            }
            conn.Close();
            return numTrxToday;
        }
       
        [WebMethod]
        public static decimal GetTotalSalesToday()
        {
            decimal totalSales = 0;
            SqlConnection conn = new SqlConnection(connStaticString);
            SqlCommand cmd = new SqlCommand("sp_TotalSalesToday", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            if (cmd.ExecuteScalar() == DBNull.Value)
            {
                totalSales = 0.0M;
            }
            else
            {
                totalSales = (decimal)cmd.ExecuteScalar();
            }
            conn.Close();
            return totalSales;
        }
        [WebMethod]
        public static decimal GetTotalTaxToday()
        {
            decimal totalTax = 0;
            SqlConnection conn = new SqlConnection(connStaticString);
            SqlCommand cmd = new SqlCommand("sp_TotalTaxToday", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            if (cmd.ExecuteScalar() == DBNull.Value)
            {
                totalTax = 0.0M;
            }
            else
            {
                totalTax = (decimal)cmd.ExecuteScalar();
            }
            conn.Close();
            return totalTax;
        }

        [WebMethod]
        public static int GetNumberOfTransactionsThisMonth()
        {
            int numTrxThisMonth = 0;
            SqlConnection conn = new SqlConnection(connStaticString);
            SqlCommand cmd = new SqlCommand("sp_NumberOfTransactionsThisMonth", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            if (cmd.ExecuteScalar() == DBNull.Value)
            {
                numTrxThisMonth = 0;
            }
            else
            {
                numTrxThisMonth = (int)cmd.ExecuteScalar();
            }
            conn.Close();
            return numTrxThisMonth;
        }

        [WebMethod]
        public static decimal GetTotalSalesThisMonth()
        {
            decimal totalSalesThisMonth = 0;
            SqlConnection conn = new SqlConnection(connStaticString);
            SqlCommand cmd = new SqlCommand("sp_TotalSalesThisMonth", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            if (cmd.ExecuteScalar() == DBNull.Value)
            {
                totalSalesThisMonth = 0.0M;
            }
            else
            {
                totalSalesThisMonth = (decimal)cmd.ExecuteScalar();
            }
            conn.Close();
            return totalSalesThisMonth;
        }
        [WebMethod]
        public static decimal GetTotalTaxThisMonth()
        {
            decimal totalTaxThisMonth = 0;
            SqlConnection conn = new SqlConnection(connStaticString);
            SqlCommand cmd = new SqlCommand("sp_TotalTaxThisMonth", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            if (cmd.ExecuteScalar() == DBNull.Value)
            {
                totalTaxThisMonth = 0.0M;
            }
            else
            {
                totalTaxThisMonth = (decimal)cmd.ExecuteScalar();
            }
            conn.Close();
            return totalTaxThisMonth;
        }

    }
}