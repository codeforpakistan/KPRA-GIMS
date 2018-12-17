namespace KPRA_RIMS_API.Classes
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Configuration;

    public class VendorSecurity
    {
        private static string connStaticString = WebConfigurationManager.ConnectionStrings["kpra_db_connection"].ConnectionString;

        public static bool AuthenticateBusiness(string username, string password)
        {
            bool hasRows = false;
            SqlConnection connection = new SqlConnection(connStaticString);
            SqlCommand command1 = new SqlCommand("sp_AuthenticateBusinessUser", connection);
            command1.CommandType = CommandType.StoredProcedure;
            command1.Parameters.AddWithValue("@username", username.ToString());
            command1.Parameters.AddWithValue("@password", password.ToString());
            connection.Open();
            SqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                hasRows = reader.HasRows;
            }
            return hasRows;
        }
    }
}

