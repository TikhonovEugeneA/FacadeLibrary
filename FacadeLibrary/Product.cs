﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeLibrary
{
    public class Product
    {
        public int ProductId {  get; set; }
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public string CategoryName {  get; set; }
        public decimal UnitPrice { get; set; }
        public int ConditionWholesale { get; set; }
        public int Discount { get; set; }
        public int ProductCount { get; set; }
    }
}
