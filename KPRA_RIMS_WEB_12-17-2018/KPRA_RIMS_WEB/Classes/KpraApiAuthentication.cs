namespace KPRA_RIMS_WEB.Classes
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;

    public class KpraApiAuthentication
    {
        public static HttpClient SendAuthentication()
        {
            HttpClient client1 = new HttpClient();
            client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client1.DefaultRequestHeaders.ConnectionClose = true;
            string str = "kpra_admin";
            string parameter = Convert.ToBase64String(Encoding.ASCII.GetBytes("kpra_admin:admin"));
            client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", parameter);
            return client1;
        }
    }
}

