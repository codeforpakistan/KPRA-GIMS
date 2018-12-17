using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace KPRA_RIMS.Classes
{
    public class OfflineActivities
    {
        private static string serverIP = ConfigurationManager.AppSettings["server_ip"].ToString();
        /// <summary>
        /// THIS CODE IS USED TO FETCH LOCAL DATABASE CONNECTION STRING FOR FURTHER CONNECTING TO THE MICROSOFT SQL SERVER DATABASE
        /// THE STRINGS ARE BOTH STATIC AND NON-STATIC FIELDS, STATIC FOR THE ACCESS BY STATIC MEMBERS OR FUNCTIONS
        /// AND NON-STATIC FOR THE NON-STATIC MEMBERS OR FUNCTIONS
        /// </summary>
        //  private string connString = "Data Source=NAZIM-PC\\NAZIMSQL; Initial Catalog=KPRA; User Id=sa;Password=123456";
        //  private static string connStaticString = "Data Source=NAZIM-PC\\NAZIMSQL; Initial Catalog=KPRA; User Id=sa;Password=123456";
        private static string connStaticString = ConfigurationManager.ConnectionStrings["kpra_db_connString"].ConnectionString;
        /// <summary>
        /// THIS CODE IS USED TO FETCH ALL THE SALE INVOICES OF EACH VENDOR WHOSE CONNECTIVITY WAS REPRESENTING THE STATUS
        /// OF BEING AS OFFLINE TO THE INTERNET AT THE TIME OF SOME SALE INVOICE ENTRY OPERATIONS
        /// </summary>
        ///
        /// <returns>A GENERIC LIST OF SALE INVOICES ARE RETURNED AT RUNTIME TO THE FUNCTION CALL</returns>
        public static List<SalesDetail> GetOfflineSalesDetail()
        {
            List<SalesDetail> lst = new List<SalesDetail>();
            SqlConnection conn = new SqlConnection(connStaticString);
            SqlCommand cmd = new SqlCommand("sp_KPRAInsertOfflineSalesDetails", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    SalesDetail salesDetail = new SalesDetail();
                    salesDetail.ProductID = Convert.ToInt64(reader["ProductID"]);
                    salesDetail.ProductName = reader["ProductName"].ToString();
                    salesDetail.Quantity = Convert.ToInt64(reader["Quantity"]);
                    salesDetail.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    salesDetail.TotalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                    salesDetail.SalesMasterIDLocal = Convert.ToInt64(reader["SalesMaster_ID"]);
                    salesDetail.BusinessIDLocal = Convert.ToInt64(reader["business_ID"]);
                    salesDetail.BusinessCode = reader["BusinessCode"].ToString();

                    lst.Add(salesDetail);
                }
    
            conn.Close();
            return lst.ToList();
        }
        public static List<Sales> GetOfflineInvoices()
        {
            List<Sales> lst = new List<Sales>();

            SqlConnection conn = new SqlConnection(connStaticString);
            SqlCommand cmd = new SqlCommand("sp_KPRAInsertOfflineSalesMaster", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sales sales = new Sales();
                sales.TotalAmount = Convert.ToDecimal(reader["totalAmount"]);
                sales.Discount = Convert.ToDecimal(reader["discount"]);
                sales.SalesTaxRate = Convert.ToDecimal(reader["salesTaxRate"]);
                sales.NetAmount = Convert.ToDecimal(reader["netAmount"]);
                sales.Paid = Convert.ToDecimal(reader["Paid"]);
                sales.TodayTime = Convert.ToDateTime(reader["salesDate2"]);
                sales.SalesTax = Convert.ToDecimal(reader["SalesTax"]);
                sales.SalesMasterIDLocal = Convert.ToInt64(reader["SalesMasterID"]);
                sales.BusinessIDLocal = Convert.ToInt64(reader["Business_ID"]);
                sales.BusinessCode = reader["BusinessCode"].ToString();
                lst.Add(sales);
            }
            conn.Close();
            return lst;
        }

        /// <summary>
        /// THIS METHOD IS A STATIC ONE, IS USED TO SEND OFFLINE INVOICES ON WINDOWS FORM ACTIVATED METHOD WHENEVER THE CONNECTION GETS ONLINE
        /// THE EVENT IS INVOKED AND RESUMES THE PROCESS OF SENDING OFFLINE INVOICES FROM THE LOCAL MACHINE TO THE SERVER SITE
        /// 
        /// </summary>
        public static string SendVendorOfflineSalesDetail()
        {
            string read = "";
            string connectionError = "";
            try
            {
                
                    HttpClient client = new HttpClient();
                    client = BusinessAuthentication.SendAuthentication();
                    string apiUrl = ConfigurationManager.AppSettings["api_url"] + "sales";
                    string inputJson = (new JavaScriptSerializer()).Serialize(OfflineActivities.GetOfflineSalesDetail());
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                   
                       HttpResponseMessage response = client.PostAsync(apiUrl + "/SalesDetailOfflineInvoice", inputContent).Result;
                      
                        if (response.IsSuccessStatusCode)
                        {
                            SalesDetail sales = new SalesDetail();
                            var readTask = response.Content.ReadAsAsync<List<SalesDetail>>().Status;
                            read = readTask.ToString();
                            SqlConnection conn = new SqlConnection(connStaticString);
                            SqlCommand cmd = new SqlCommand("sp_ClientConnectionStatusInOfflineActivityToNullInSales_Details", conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        else
                        {

                        }
                
            }
            catch (SocketException ex)
            {
                string s = ex.ToString();
                //return false;
            }
            //catch (System.Net.Sockets.SocketException socketEx)
            //{
            //    read += socketEx.Message + "\r\n" + socketEx.StackTrace;
            //}
            catch (System.Net.WebException socketEx)
            {
                read += socketEx.Message + "\r\n" + socketEx.StackTrace;
            }
            catch (AggregateException ex)
            {
                foreach (Exception inner in ex.InnerExceptions)
                {
                    Console.WriteLine("Exception type {0} from {1}", inner.GetType(), inner.Source);
                    read+=inner.GetType()+" "+ inner.Source;
                }

            }
         
            ////catch (SystemException sysEx)
            ////{ }
            ////catch (Exception ex)
            ////{ }
            //catch (System.Net.Sockets.SocketException socketEx)
            //{
            //    read += socketEx.Message + "\r\n";
            //}
            //catch (System.Net.WebException socketEx)
            //{
            //    read += socketEx.Message + "\r\n";
            //}
         
            return read;
        }
        public static string SendVendorOfflineInvoices()
        {
            string read="";
            string connectionError = "";
            try
            {
                    HttpClient client = new HttpClient();
                    client = BusinessAuthentication.SendAuthentication();
                    string apiUrl = ConfigurationManager.AppSettings["api_url"] + "sales";
                    string inputJson = (new JavaScriptSerializer()).Serialize(OfflineActivities.GetOfflineInvoices());
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                                  
                                        HttpResponseMessage response = client.PostAsync(apiUrl + "/salesofflineinvoice", inputContent).Result;
                                        if (response.IsSuccessStatusCode)
                                        {
                                            Sales sales = new Sales();
                                            var readTask = response.Content.ReadAsAsync<List<Sales>>().Status;
                                            read = readTask.ToString();
                                            SqlConnection conn = new SqlConnection(connStaticString);
                                            SqlCommand cmd = new SqlCommand("sp_ClientConnectionStatusInOfflineActivityToNullInSales_Master", conn);
                                            conn.Open();
                                            cmd.ExecuteNonQuery();
                                            conn.Close();
                                        }
                                        else
                                            {
                                                
                                            }
            }
            catch (SystemException ex)
            {
                read = "Exception: " + ex.Message.ToString();
            }
            catch (Exception ex)
            {
               read = "Exception: " + ex.Message.ToString();
            }
            
            return read;
        }
    }
}
