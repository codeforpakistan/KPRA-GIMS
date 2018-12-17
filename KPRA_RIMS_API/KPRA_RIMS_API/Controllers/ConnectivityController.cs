namespace KPRA_RIMS_API.Controllers
{
    using KPRA_RIMS;
    using KPRA_RIMS_API.Classes;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Net;
    using System.Net.Http;
    using System.Web.Configuration;
    using System.Web.Http;

    [BasicAuthentication]
    public class ConnectivityController : ApiController
    {
        private HttpResponseMessage resp;
        private string connString = WebConfigurationManager.ConnectionStrings["kpra_db_connection"].ConnectionString;

        [HttpPost]
        public HttpResponseMessage InsertStatus([FromBody] NetworkInfo inputContent)
        {
            SqlConnection connection = new SqlConnection(this.connString);
            try
            {
               
               // string insStatus= "INSERT INTO InternetStatus(statusCheck, userID,businessIDLocal,businessCode) VALUES('"+inputContent.NetworkAvailability+"', '"+inputContent.UserID+"','"+inputContent.BusinessIDLocal+"','"+inputContent.BusinessCode+"')";
                SqlCommand stateObject = new SqlCommand("sp_InsertNetStatus", connection);
                stateObject.CommandType = CommandType.StoredProcedure;
                stateObject.Parameters.AddWithValue("@statusCheck", inputContent.NetworkAvailability);
                stateObject.Parameters.AddWithValue("@userID", inputContent.UserID);
                stateObject.Parameters.AddWithValue("@businessIDLocal", inputContent.BusinessIDLocal);
                stateObject.Parameters.AddWithValue("@businessCode", inputContent.BusinessCode);
                connection.Open();
                IAsyncResult result = stateObject.BeginExecuteNonQuery(new AsyncCallback(AsynchSql.CallBack), stateObject);
                while (!result.IsCompleted)
                {
                    this.resp = base.Request.CreateResponse<NetworkInfo>(HttpStatusCode.Created, inputContent);
                }
            }
            catch (SqlException)
            {
            }
            catch (Exception)
            {
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
            }
            return this.resp;
        }

        [HttpGet]
        public HttpResponseMessage RetrieveStatus()
        {
            List<ClientUsers> list = new List<ClientUsers>();
            SqlConnection connection = new SqlConnection(this.connString);
            SqlCommand command1 = new SqlCommand("sp_clientLoginTimeStatus", connection);
            command1.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                if (!reader.HasRows)
                {
                    this.resp = base.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Client status not found!");
                    continue;
                }
                ClientUsers item = new ClientUsers {
                    ConnectionStatus = reader["statusCheck"].ToString(),
                    BusinessName = reader["businessName"].ToString(),
                    Address = reader["address"].ToString(),
                    ConnectedSince = (reader["connectedSince"] != DBNull.Value) ? Convert.ToInt32(reader["connectedSince"]) : -1
                };
                if (reader["LoginTime"] != DBNull.Value)
                {
                    item.NowTime = new DateTime?(DateTime.Parse(reader["LoginTime"].ToString()));
                }
                else
                {
                    item.NowTime = null;
                }
                item.UserID = (reader["userID"] != DBNull.Value) ? Convert.ToInt32(reader["userID"]) : 0;
                list.Add(item);
                this.resp = base.Request.CreateResponse<List<ClientUsers>>(HttpStatusCode.OK, list);
            }
            connection.Close();
            return this.resp;
        }

        [HttpGet]
        public HttpResponseMessage RetrieveStatusByTime(string beginTime, string endTime)
        {
            List<ClientUsers> list = new List<ClientUsers>();
            SqlConnection connection = new SqlConnection(this.connString);
            SqlCommand command1 = new SqlCommand("sp_clientLoginTimeStatusByTime", connection);
            command1.CommandType = CommandType.StoredProcedure;
            command1.Parameters.AddWithValue("@beginTime", beginTime);
            command1.Parameters.AddWithValue("@endTime", endTime);
            connection.Open();
            SqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                if (!reader.HasRows || (reader["userID"] == DBNull.Value))
                {
                    this.resp = base.Request.CreateErrorResponse(HttpStatusCode.NotFound, "No client status in between these dates found!");
                    continue;
                }
                ClientUsers item = new ClientUsers {
                    ConnectionStatus = reader["statusCheck"].ToString(),
                    UserName = reader["userName"].ToString()
                };
                if (reader["LoginTime"] != DBNull.Value)
                {
                    item.NowTime = new DateTime?(DateTime.Parse(reader["LoginTime"].ToString()));
                }
                else
                {
                    item.NowTime = null;
                }
                item.UserID = (reader["userID"] != DBNull.Value) ? Convert.ToInt32(reader["userID"]) : 0;
                list.Add(item);
                this.resp = base.Request.CreateResponse<List<ClientUsers>>(HttpStatusCode.OK, list);
            }
            connection.Close();
            return this.resp;
        }
    }
}

