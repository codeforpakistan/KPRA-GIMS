using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Configuration;

namespace KPRA_RIMS
{
    class LogOnInfoClass
    {
        public static void setLogonInfo(ReportDocument c)
        {
            foreach (Table t in c.Database.Tables)
            {
             
                TableLogOnInfo tloi = new TableLogOnInfo(t.LogOnInfo);
                LogOnInfoClass obj=new LogOnInfoClass();
                tloi.ConnectionInfo.ServerName = ConfigurationManager.AppSettings["server_name"].ToString();
               //   tloi.ConnectionInfo.ServerName = "NAZIM-PC\\NAZIMSQL";

                tloi.ConnectionInfo.DatabaseName = ConfigurationManager.AppSettings["db_name"];


               
                                tloi.ConnectionInfo.IntegratedSecurity = true;

               
               // tloi.ConnectionInfo.UserID = "sa";
                //tloi.ConnectionInfo.Password = "1234";


                t.ApplyLogOnInfo(tloi);

            }
            //foreach (ReportDocument sub in c.Subreports)
            //{
            //    setLogonInfo(sub);
            //}
             }

        
    }
}
