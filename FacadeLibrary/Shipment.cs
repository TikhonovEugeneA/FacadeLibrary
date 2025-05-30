using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeLibrary
{
    public class Shipment
    {
        public string product_name {  get; set; }
        public string category { get; set; }
        public string manufacturer { get; set; }
        public string company_name {  get; set; }
        public DateTime shipment_date { get; set; }
        public int product_count { get; set; }
    }
}
