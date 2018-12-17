using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KPRA_RIMS.Classes
{
    public class WebAPIResource
    {
       public static string statusCodes;
        public static bool CheckHttpStatusCode()
        {
          //  StatusCodes statusCodes = new StatusCodes();
            
            bool isSuccess=false;
            HttpClient client = new HttpClient();
            client = BusinessAuthentication.SendAuthentication();
            string apiUrl = ConfigurationManager.AppSettings["api_url"];
            HttpResponseMessage response = null;
            try
            {
                response = client.GetAsync(apiUrl+"/connectivity/retrievestatus").Result;
                if(response.IsSuccessStatusCode)
                {
                    isSuccess = response.IsSuccessStatusCode;
                    statusCodes= response.StatusCode.ToString();
                   // statusCodes.StatusCodeInteger =(int) response.StatusCode;
                }
                else
                {
                    isSuccess = response.IsSuccessStatusCode;
                    statusCodes= response.StatusCode.ToString();
                   // statusCodes.StatusCodeInteger = (int)response.StatusCode;
                }
            }
            catch(Exception ex)
            {
                statusCodes = "ERROR: " + ex;
            }
            return isSuccess;
        }
       
        
    }
}
