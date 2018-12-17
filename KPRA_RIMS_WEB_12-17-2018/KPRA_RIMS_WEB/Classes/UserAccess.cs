namespace KPRA_RIMS_WEB.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Configuration;

    public class UserAccess
    {
        private static string connStaticString = WebConfigurationManager.ConnectionStrings["KPRAConnectionString"].ConnectionString;

        public static List<Users> MatchCreds(string username, string password)
        {
            List<Users> source = new List<Users>();
            SqlConnection connection = new SqlConnection(connStaticString);
            SqlCommand command1 = new SqlCommand("sp_UserCredentialCheck", connection);
            command1.CommandType = CommandType.StoredProcedure;
            command1.Parameters.AddWithValue("@username", username);
            command1.Parameters.AddWithValue("@password", password);
            connection.Open();
            SqlDataReader reader = command1.ExecuteReader();
            while (reader.Read() && reader.HasRows)
            {
                Users item = new Users {
                    UserID = Convert.ToInt32(reader["user_id"]),
                    UserName = reader["user_name"].ToString(),
                    Password = reader["password"].ToString(),
                    BusinessID = Convert.ToInt32(reader["business_id"])
                };
                source.Add(item);
            }
            return source.ToList<Users>();
        }
    }
}

