using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FacadeLibrary
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserLastName { get; set; }
        public string UserFirstName { get; set; }
        public string UserPhone { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderCost {  get; set; }
        public string Status { get; set; }
    }
}
