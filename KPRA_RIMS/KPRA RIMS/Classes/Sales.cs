using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPRA_RIMS.Classes
{
    /// <summary>
    /// THIS IS A PUBLIC CLASS CALLED SALES THAT IS USED TO DEFINE THE STRUCTURE OF THE SALE INVOICE
    /// THE CLASS IS DECLARED PUBLIC BECAUSE IT WILL BE USED AS REFERENCE TO THE OTHER PROJECTS IN THE PROJECT ARCHITECTURE
    /// THE CLASS DECLARES ATTRIBUTES/PROPERTIES AND HAS STILL NOT FUNCTIONS AT ALL AT THIS TIME
    /// THE CLASS MAY HAVE TO BE SCALED ON NEED AND REQUIREMENTS OF THE DEPARTMENT ACCORDING TO THE AUTHORITY PRESCRIPTIONS
    /// </summary>
  public  class Sales
    {
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public  decimal SalesTaxRate { get; set; }
        public decimal SalesTax { get; set; }
        public decimal NetAmount { get; set; }
        public decimal Paid { get; set; }
        public int BusinessID { get; set; }
        public int StationID { get; set; }
        public DateTime? TodayTime { get; set; }
        public bool IsConnected { get; set; }
        public string SalesDate { get; set; }
        public string Description { get; set; }
        public decimal OtherCharges{ get; set; }
        public long SalesMasterIDLocal { get; set; }
        public long BusinessIDLocal { get; set; }
        public string BusinessCode { get; set; }
    }
}
