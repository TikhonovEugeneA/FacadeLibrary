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
        public List<Product> products { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderCost {  get; set; }
        public string Status { get; set; }
    }
}
