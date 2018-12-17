using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace KPRA_RIMS.Classes
{
   public class BusinessAuthentication
    {
      private static string connString = WebConfigurationManager.ConnectionStrings["kpra_db_connString"].ConnectionString;

        private static string Base64VendorCredentials()
        {
            Credentials creds = new Credentials();
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("SELECT Username, Password FROM Business", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    

                    creds.Username = reader["Username"].ToString();
                    creds.Password = reader["Password"].ToString();
                }
            }
            conn.Close();
            var username = creds.Username;
            var password = creds.Password;
            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes(""+username+":"+password+""));
            return base64String;
        }
        public static HttpClient SendAuthentication()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.ConnectionClose = true;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Base64VendorCredentials());

            return client;
        }
        
    }
}
