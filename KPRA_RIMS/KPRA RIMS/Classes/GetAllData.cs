using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using KPRA_RIMS;

namespace KPRA
{
    class GetAllData
    {
        SqlConnection con = ConnectionClass.SQLCONNECTION();
        public SqlDataReader GetAllDataByUser(string tbl_name)
        {
            try
            {
                con.Close();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string sSql = "select *from " + tbl_name + "";
                SqlCommand cmd = new SqlCommand(sSql, con);
                return cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally {

                //con.Close();
            
            }
            
        }
        public SqlDataReader GetSelectedData(string sSql)
        {
            try
            {
                con.Close();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(sSql, con);
                return cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {

                //con.Close();

            }

        }
    }
}
