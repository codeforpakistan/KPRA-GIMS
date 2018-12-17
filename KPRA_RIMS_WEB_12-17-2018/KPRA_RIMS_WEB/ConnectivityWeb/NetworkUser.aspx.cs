using KPRA_RIMS_API.Classes;
using KPRA_RIMS_WEB.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPRA_RIMS_WEB.ConnectivityWeb
{
    public partial class NetworkUser : System.Web.UI.Page
    {
        public static List<ClientUsers> GetNetworkData()
        {
            StringBuilder builder = new StringBuilder();
            List<ClientUsers> list = new List<ClientUsers>();
            HttpClient client1 = new HttpClient();
            string uriString = WebConfigurationManager.AppSettings["api_url"].ToString();
            HttpClient client2 = KpraApiAuthentication.SendAuthentication();
            client2.BaseAddress = new Uri(uriString);
            Task<HttpResponseMessage> async = client2.GetAsync("connectivity/retrievestatus");
            async.Wait();
            HttpResponseMessage result = async.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<IList<ClientUsers>> task2 = result.Content.ReadAsAsync<IList<ClientUsers>>();
                task2.Wait();
                foreach (ClientUsers users in task2.Result)
                {
                    ClientUsers item = new ClientUsers {
                        ConnectionStatus = users.ConnectionStatus,
                        NowTime = users.NowTime,
                        UserID = users.UserID,
                        BusinessName = users.BusinessName,
                        Address = users.Address,
                        ConnectedSince = users.ConnectedSince
                    };
                    list.Add(item);
                }
                return list;
            }
            builder.Append("Error:"+(int) result.StatusCode+ "-- Error Details: "+result.ReasonPhrase);
            return list;
        }

        [WebMethod, ScriptMethod]
        public static List<ClientUsers> GetNetworkUsers()
        {
            List<ClientUsers> list = new List<ClientUsers>();
            foreach (ClientUsers users in GetNetworkData())
            {
                ClientUsers item = new ClientUsers {
                    StatusImage = "/Images/onlinestatus.png",
                    ConnectionStatus = users.ConnectionStatus,
                    BusinessName = users.BusinessName,
                    Address = users.Address,
                    NowTime = users.NowTime,
                    UserID = users.UserID,
                    ConnectedSince = users.ConnectedSince
                };
                list.Add(item);
            }
            return list;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}