using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Data;

namespace KPRA_RIMS.Classes
{
    public class InternetConnection
    {
       static string serverIP = ConfigurationManager.AppSettings["server_ip"].ToString();
        public static bool CheckServerConnectivity(string ipAddress)
        {
            bool connectionExists = false;
            string status = "";
            try
            {

                System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
                options.DontFragment = true;
                if (!string.IsNullOrEmpty(ipAddress))
                {
                    System.Net.NetworkInformation.PingReply reply = pingSender.Send(ipAddress);

                    connectionExists = reply.Status == System.Net.NetworkInformation.IPStatus.Success ? true : false;

                }
            }
            catch (PingException ex)
            {
                status = ex.Message.ToString();
            }
            catch (AggregateException ex)
            {
                foreach (Exception inner in ex.InnerExceptions)
                {
                    status = inner.Message.ToString();
                }
            }
            return connectionExists;
        }
        public static string GetBusinessCode()
        {
            DataTable dt = ConnectionClass.Selectcommand("select businessCode from business");
            return dt.Rows[0][0].ToString();

        }
        public static long GetBusinessID()
        {
          DataTable dt=  ConnectionClass.Selectcommand("select business_ID from business");
            return Convert.ToInt64(dt.Rows[0][0]);
           
        }
        public static void SendClientStatus()
        {
            string connectionError = "";
            NetworkInfo netInfo = new NetworkInfo();
            //netInfo.UserName = "sami";
            //netInfo.Password = "12345";
            netInfo.UserID = 1;
          //  InternetConnection ic = new InternetConnection();
            netInfo.BusinessIDLocal = InternetConnection.GetBusinessID();
            netInfo.NetworkAvailability = IsConnectedToInternet().ToString();
            netInfo.BusinessCode = InternetConnection.GetBusinessCode().ToString();
           
                HttpClient client = new HttpClient();
                client = BusinessAuthentication.SendAuthentication();

                string apiUrl = ConfigurationManager.AppSettings["api_url"] + "Connectivity";
                string inputJson = (new JavaScriptSerializer()).Serialize(netInfo);
                HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                try
                {
                        response = client.PostAsync(apiUrl + "/insertstatus", inputContent).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var readTask = response.Content.ReadAsAsync<NetworkInfo>();
                            // lblNetworkInfo.Text = readTask.ToString();
                        }
                        else
                        {
                            ///code for no status of 200 OK
                        }
                    
                }
                catch (AggregateException ex)
                {
                    foreach (Exception inner in ex.InnerExceptions)
                    {
                        Console.WriteLine("Exception type {0} from {1}",inner.GetType(),inner.Source);
                    }
                }
           
        }
        /// <summary>
        /// IMPORT BY SAJID
        /// THIS IMPORT RETURNS A DLL LIBRARY THAT HAS THE CAPABILITY TO CHECK INTERNET CONNECTIVITY BY USING BUILT-IN CODE
        /// </summary>
        /// <param name="Description">THE PARAM IS USED TO PASS DESCRIPTION VALUE TO THE LIBRARY</param>
        /// <param name="ReservedValue">BY DEFAULT WE KEEP THIS VALUE 0 THE PASS TO THE LIBRARY</param>
        /// <returns></returns>
        [DllImport("wininet.dll")]
        public extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        /// <summary>
        /// CODE BY SAJID
        /// THIS CODE IS USED TO CHECK VENDOR-SIDE CONNECTIVITY TO THE INTERNET
        /// </summary>
        /// <returns>RETURNS FALSE (0) IF NOT CONNECTED, IN THE ELSE CASE RETURNS TRUE(1)</returns>
        public static bool IsConnectedToInternet()
        {
            bool returnValue = false;
            try
            {

                int Desc;
                returnValue = InternetConnection.InternetGetConnectedState(out Desc, 0);
            }
            catch
            {
                returnValue = false;
            }
            return returnValue;
        }

    }
}