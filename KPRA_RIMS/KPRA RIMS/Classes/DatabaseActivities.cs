using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPRA_RIMS.Classes
{
    class DatabaseActivities
    {
       private static string connString = ConfigurationManager.ConnectionStrings["kpra_db_connString"].ConnectionString;

       public static string GetBusinessCode()
       {
           Sales sales = new Sales();
           string businessCode="";
           SqlConnection conn = new SqlConnection(connString);

           SqlCommand cmd = new SqlCommand("sp_ClientBusinessCode", conn);
           cmd.CommandType = System.Data.CommandType.StoredProcedure;
           conn.Open();
           SqlDataReader reader = cmd.ExecuteReader();

           while (reader.Read())
           {
               sales.BusinessCode = reader["BusinessCode"].ToString();
               businessCode = sales.BusinessCode;
           }
           conn.Close();
           return businessCode.ToString();
       }
       


    }
}
