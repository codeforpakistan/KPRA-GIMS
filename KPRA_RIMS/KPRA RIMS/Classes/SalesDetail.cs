using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPRA_RIMS.Classes
{
    /// <summary>
    /// THIS IS A PUBLIC CLASS CALLED SALES DETAIL THAT IS USED TO DEFINE THE STRUCTURE OF THE SALE DETAILS ON GIVEN INVOICES
    /// THE CLASS IS DECLARED PUBLIC BECAUSE IT WILL BE USED AS REFERENCE TO THE OTHER PROJECTS IN THE PROJECT ARCHITECTURE
    /// THE CLASS DECLARES ATTRIBUTES/PROPERTIES AND HAS STILL NOT FUNCTIONS AT ALL AT THIS TIME
    /// THE CLASS MAY HAVE TO BE SCALED ON NEED AND REQUIREMENTS OF THE DEPARTMENT OR ACCORDING TO THE AUTHORITY PRESCRIPTIONS
    /// </summary>
    public class SalesDetail
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public long Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public long SalesMasterID { get; set; }
        public long SalesMasterIDLocal { get; set; }
        public long BusinessIDLocal { get; set; }
        public string BusinessCode { get; set; }
    }
}
