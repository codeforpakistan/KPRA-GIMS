namespace KPRA_RIMS_WEB.ClassesReport
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Web.Configuration;

    public class WebMethods
    {
        private static string connStaticString = WebConfigurationManager.ConnectionStrings["KPRAConnectionString"].ConnectionString;

        public static List<string> FetchBusinessCodeFromDB(string businessCode)
        {
            List<string> list2;
            List<string> list = new List<string>();
            using (SqlConnection connection = new SqlConnection(connStaticString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select businessCode from business where businessCode LIKE ''+@businessCode+'%'";
                    command.Connection = connection;
                    connection.Open();
                    command.Parameters.AddWithValue("@businessCode", businessCode);
                    SqlDataReader reader = command.ExecuteReader();
                    while (true)
                    {
                        if (!reader.Read())
                        {
                            connection.Close();
                            list2 = list;
                            break;
                        }
                        list.Add(reader["businessCode"].ToString());
                    }
                }
            }
            return list2;
        }

        public static List<string> FetchBusinessNameFromDB(string businessName)
        {
            List<string> list2;
            List<string> list = new List<string>();
            using (SqlConnection connection = new SqlConnection(connStaticString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select businessName from business where businessName LIKE ''+@businessName+'%'";
                    command.Connection = connection;
                    connection.Open();
                    command.Parameters.AddWithValue("@businessName", businessName);
                    SqlDataReader reader = command.ExecuteReader();
                    while (true)
                    {
                        if (!reader.Read())
                        {
                            connection.Close();
                            list2 = list;
                            break;
                        }
                        list.Add(reader["businessName"].ToString());
                    }
                }
            }
            return list2;
        }
    }
}

