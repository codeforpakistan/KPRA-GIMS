using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPRA_RIMS.Classes
{
    public class SalesMasterForLocal
    {
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal SalesTaxRate { get; set; }
        public decimal SalesTax { get; set; }
        public decimal NetAmount { get; set; }
        public decimal Paid { get; set; }
        public string BusinessCode { get; set; }
        public long StationID { get; set; }
        public string SalesDate { get; set; }
        public bool isConnected { get; set;}
        public DateTime SalesDate2 { get; set; }

    }
}
