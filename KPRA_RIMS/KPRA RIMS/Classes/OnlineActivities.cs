using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace KPRA_RIMS.Classes
{
    public class OnlineActivities
    {
        private static string serverIP = ConfigurationManager.AppSettings["server_ip"].ToString();
        private static string connStaticString = ConfigurationManager.ConnectionStrings["kpra_db_connString"].ConnectionString;
        static  List<SalesMasterForLocal> lst = new List<SalesMasterForLocal>();
        public static void UpdateSalesDetailConnection()
        {
            SqlConnection conn = new SqlConnection(connStaticString);
            SqlCommand cmd = new SqlCommand("sp_ClientUpdateSalesDetailConnection",conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static List<SalesDetail> GetOnlineSalesDetailDB()
        {
            List<SalesDetail> lst = new List<SalesDetail>();
            SqlConnection conn = new SqlConnection(connStaticString);
            SqlCommand cmd = new SqlCommand("sp_ClientSalesDetailOnline", conn);
           
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@salesMasterID", GetLastMasterIDLocal());
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() && reader.HasRows)
            {
                SalesDetail salesDetail = new SalesDetail();
                salesDetail.ProductID = Convert.ToInt64(reader["ProductID"]);
                salesDetail.ProductName = reader["ProductName"].ToString();
                salesDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                salesDetail.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                salesDetail.TotalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                salesDetail.SalesMasterIDLocal = Convert.ToInt64(reader["SalesMaster_ID"]);
                lst.Add(salesDetail);
            }
            conn.Close();
            return lst;
        }
        /// <summary>
        /// BY TRANSFERRING REALTIME VOUCHERS AND SALE INVOICES IS PREREQUISITE TO EVERY SERVER-SIDE RIMS APPLICATION.
        /// THIS DETAILED SALE INVOICE IS USED TO TRANSFER INVOICING DATA TO THE RELEVANT SERVER BY ONE BUTTON CLICK.
        /// </summary>
        /// <param name="totalAmount">THIS PARAM REPRESENTS THE TOTAL AMOUNT OF INVOICE CREATED</param>
        /// <param name="discount">THIS PARAM REPRESENTS DISCOUNT RATES OFFERED TO CUSTOMERS</param>
        /// <param name="salesTaxRate">THIS PARAM REPRESENTS SALES TAX RATE</param>
        /// <param name="salesTax">THIS PARAM REPRESENTS SALES TAX ON SERVICES AS PER TOTAL SUM OF INVOICE</param>
        /// <param name="netAmount">THIS PARAM REPRESENTS NET AMOUNT OF THE INVOICE CREATED</param>
        /// <param name="paid">THIS PARAM REPRESENTS MONEY PAID BY THE CUSTOMER</param>
        /// <param name="todayTime">THIS PARAM REPRESENTS CURRENT DATE AND TIME OF INVOICE CREATED ON</param>
        /// <param name="businessID">THIS PARAM REPRESENTS BUSINESS ID OF PER BUSINESS FIRM OR COMPANY</param>
        /// <param name="stationID">THIS PARAM REPRESENTS STATION IDENTIFIER OF EACH STATION LINKED WITH A PARTICULAR BUSINESS FIRM OR COMPANY </param>
        /// <param name="description">THIS PARAM REPRESENTS THE EXPLAINATION OF THE INVOICE</param>
        /// <param name="otherCharges">THIS PARAM REPRESENTS MISCELLANEOUS CHARGES RENDERD</param>
        public static void SendOnlineSalesDetail(long productID, string productName, int quantity,
            decimal unitPrice, decimal totalPrice, long salesMasterIDLocal,long businessIDLocal,string businessCode)
        {
            string results;
            string connectionError = "";
            try
            {
                SalesDetail salesDetail = new SalesDetail();
                salesDetail.ProductID = productID;
                salesDetail.ProductName = productName;
                salesDetail.Quantity = quantity;
                salesDetail.UnitPrice = unitPrice;
                salesDetail.TotalPrice = totalPrice;
                salesDetail.SalesMasterIDLocal = salesMasterIDLocal;
                salesDetail.BusinessIDLocal = businessIDLocal;
                salesDetail.BusinessCode = businessCode;

                //using (var client = new HttpClient())
                //{
                HttpClient client = new HttpClient();
                client = BusinessAuthentication.SendAuthentication();
                    string apiUrl = ConfigurationManager.AppSettings["api_url"] + "sales";
                    string inputJson = (new JavaScriptSerializer()).Serialize(salesDetail);
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                    try
                {
                    HttpResponseMessage response = client.PostAsync(apiUrl + "/SalesDetail", inputContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        results = response.Content.ReadAsStringAsync().Result.ToString();
                        SqlConnection conn = new SqlConnection(connStaticString);
                        SqlCommand cmd = new SqlCommand("sp_InvertClientUpdateConnectionStateFromOneToNullInSales_Details", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    else
                    {
                        //update isconnected value to 0 in sales_details table where isConnected is equal to 1 recently
                        SqlConnection conn = new SqlConnection(connStaticString);
                        SqlCommand cmd = new SqlCommand("sp_InvertClientUpdateConnectionStatusInSales_Details", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    
                }
                catch(Exception ex)
                {
                    SqlConnection conn = new SqlConnection(connStaticString);
                    SqlCommand cmd = new SqlCommand("sp_InvertClientUpdateConnectionStatusInSales_Details", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                      
                    
                    
                   
                //}
            }
            catch {
                SqlConnection conn = new SqlConnection(connStaticString);
                SqlCommand cmd = new SqlCommand("sp_InvertClientUpdateConnectionStatusInSales_Details", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        /// <summary>
        /// Getting Most Recent Purchase Transaction ID from DB
        /// </summary>
        /// <returns>Returns Most Recent SalesMasterID</returns>
        public static long GetLastMasterIDLocal()
        {
            Sales sales = new Sales();
            SqlConnection conn = new SqlConnection(connStaticString);
            SqlCommand cmd = new SqlCommand("SELECT MAX(SalesMasterID)) from Sales_Master");
            conn.Open();
            SqlDataReader reader=cmd.ExecuteReader();
            while (reader.Read())
            {
                sales.SalesMasterIDLocal = Convert.ToInt64(reader["SalesMasterID"]);
            }
            conn.Close();
            return sales.SalesMasterIDLocal;
        }
        public static List<SalesMasterForLocal> StoreSalesMasterDataOnline(decimal totalAmount, decimal discount,
         decimal salesTaxRate, decimal salesTax, decimal netAmount, decimal paid,
         bool isConnected, string businessCode, long stationID, string salesDate, DateTime salesDate2)
        {
            
            foreach (var items in lst)
            {
                SalesMasterForLocal local = new SalesMasterForLocal();
                local.TotalAmount = totalAmount;
                local.Discount = discount;
                local.SalesTaxRate = salesTaxRate;
                local.SalesTax = salesTax;
                local.NetAmount = netAmount;
                local.Paid = paid;
                local.isConnected = isConnected;
                local.BusinessCode = businessCode;
                local.StationID = stationID;
                local.SalesDate = salesDate;
                local.SalesDate2 = salesDate2;
                lst.Add(local);
            }
            return lst;
        }
        public static void SendOnlineInvoice(double totalAmount, decimal discount, double salesTaxRate, double salesTax, double netAmount,
            double paid, DateTime? todayTime, string description, double otherCharges,long salesMasterID,long businessIDLocal,string businessCode)
        {
            #region local vars
            string results;
            string connectionError = "";
           
                Sales sales = new Sales();

                sales.TotalAmount = Convert.ToDecimal(totalAmount);
                sales.Discount = discount;
                sales.SalesTaxRate = Convert.ToDecimal(salesTaxRate);
                sales.SalesTax = Convert.ToDecimal(salesTax);
                sales.NetAmount = Convert.ToDecimal(netAmount);
                sales.Paid = Convert.ToDecimal(paid);
                sales.TodayTime = todayTime;
                sales.Description = description;
                sales.OtherCharges = Convert.ToDecimal(otherCharges);
                sales.SalesMasterIDLocal = Convert.ToInt64(salesMasterID);
                sales.BusinessIDLocal = businessIDLocal;
                sales.BusinessCode = businessCode;
            #endregion
                //using (var client = new HttpClient())
                //{
                 HttpClient client = new HttpClient();
                   client= BusinessAuthentication.SendAuthentication();
                    string apiUrl = ConfigurationManager.AppSettings["api_url"] + "sales";
                   
                    string inputJson = (new JavaScriptSerializer()).Serialize(sales);
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                 try
            {
                HttpResponseMessage response = null;

                response = client.PostAsync(apiUrl + "/salesinvoice", inputContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    results = response.Content.ReadAsStringAsync().Result.ToString();
                    SqlConnection conn = new SqlConnection(connStaticString);
                    SqlCommand cmd = new SqlCommand("sp_InvertClientUpdateConnectionStateFromOneToNullInSales_Master", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                else
                {
                    //update isConnected value to 0 in sales_master table where isConnected Value happened to be 1 recently
                    SqlConnection conn = new SqlConnection(connStaticString);
                    SqlCommand cmd = new SqlCommand("sp_InvertClientUpdateConnectionStatusInSales_Master", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
            catch(Exception ex)
            {
                //update isConnected value to 0 in sales_master table where isConnected Value happened to be 1 recently
                SqlConnection conn = new SqlConnection(connStaticString);
                SqlCommand cmd = new SqlCommand("sp_InvertClientUpdateConnectionStatusInSales_Master", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }



        }
    }
}