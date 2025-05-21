using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacadeLibrary;
using Npgsql;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBFacade dBFacade = DBFacade.GetInstance("Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway");
            //foreach (var pro in dBFacade.GetProductList())
            //{
            //    Console.WriteLine(pro.ProductId + " " + pro.ProductName + " " + pro.Manufacturer + " " + pro.CategoryName);
            //}
            //foreach(var s in dBFacade.GetStatusList())
            //{
            //    Console.WriteLine(s);
            //}
            //foreach(var o in dBFacade.GetOrderListForEmployes())
            //{
            //    Console.WriteLine(o.OrderId + " " + o.User.FirstName + " " + o.User.LastName + " " + o.User.Phone);
            //}
            Console.WriteLine(dBFacade.Login("79132002020","123").Role.ToString());
        }
    }
}
