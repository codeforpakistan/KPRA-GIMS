using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPRA_RIMS
{
   public class NetworkInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NetworkAvailability { get; set; }
        public int UserID { get; set; }
        public long UserIDLocal { get; set; }
        public long BusinessIDLocal { get; set; }
        public string BusinessCode { get; set; }
    }
}
