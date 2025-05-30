using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeLibrary
{
    public class Cart
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string category_name { get; set; }
        public string manufacturer { get; set; }
        public decimal unit_price { get; set; }
        public int condition_wholesale { get; set; }
        public int discount { get; set; }
        public int product_count { get; set; }
        public int product_count_in_cart { get; set; }
    }
}
