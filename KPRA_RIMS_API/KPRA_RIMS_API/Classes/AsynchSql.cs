namespace KPRA_RIMS_API.Classes
{
    using System;
    using System.Data.SqlClient;

    public class AsynchSql
    {
        public static void CallBack(IAsyncResult result)
        {
            try
            {
                ((SqlCommand) result.AsyncState).EndExecuteNonQuery(result);
            }
            catch (Exception)
            {
            }
        }
    }
}

