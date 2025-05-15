using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using FacadeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsFacade
{
    [TestClass]
    public class DBFacadeTests
    {
        [TestMethod]
        public void TestGetUserRole()
        {
            DBFacade dBFacade = DBFacade.GetInstance("Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway");
            string value = dBFacade.GetUserRole("79131001010", "123");
            string trueValue = "admin";
            Assert.AreEqual(trueValue,value);
        }
        [TestMethod]
        public void TestGetStatusList()
        {
            DBFacade dBFacade = DBFacade.GetInstance("Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway");
            List<string> value = dBFacade.GetStatusList();
            List<string> trueValue = new List<string>(){"Принят","В сборке","Собран","Запрошен","Передан","Выдан","Возврат","Разобран"};
            Assert.AreEqual(trueValue[0], value[0]);
        }
        [TestMethod]
        public void TestGetProductList()
        {
            DBFacade dBFacade = DBFacade.GetInstance("Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway");
            Product expectedProduct = new Product()
            {
                ProductName = "Шуруповерт",
                Manufacturer = "Bosch",
                CategoryName = "Инструменты",
                UnitPrice = 12500,
                ConditionWholesale = 3,
                Discount = 5,
                ProductCount = 15
            };

            List<Product> actualProducts = dBFacade.GetProductList();

            Product actualProduct = actualProducts.FirstOrDefault(p =>
                p.ProductName == expectedProduct.ProductName &&
                p.Manufacturer == expectedProduct.Manufacturer);

            Assert.AreEqual(expectedProduct.ProductName, actualProduct.ProductName);
            Assert.AreEqual(expectedProduct.Manufacturer, actualProduct.Manufacturer);
            Assert.AreEqual(expectedProduct.CategoryName, actualProduct.CategoryName);
            Assert.AreEqual(expectedProduct.UnitPrice, actualProduct.UnitPrice);
            Assert.AreEqual(expectedProduct.ConditionWholesale, actualProduct.ConditionWholesale);
            Assert.AreEqual(expectedProduct.Discount, actualProduct.Discount);
            Assert.AreEqual(expectedProduct.ProductCount, actualProduct.ProductCount);
        }
        [TestMethod]
        public void TestGetOrdertListForEmployes()
        {
            DBFacade dBFacade = DBFacade.GetInstance("Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway");
            Order expectedOrder = new Order()
            {
                OrderId = 7,
                User = new User()
                {
                    FirstName = "Петр",
                    LastName = "Петров",
                    Phone = "79132002020"
                },
                OrderDate = new DateTime(2025,05,15),
                OrderCost = 54915.00M,
                Status = "Принят",
            };

            List<Order> actualProducts = dBFacade.GetOrderListForEmployes();

            Order actualProduct = actualProducts.FirstOrDefault(p =>
                p.OrderId == expectedOrder.OrderId);

            Assert.AreEqual(expectedOrder.OrderId, actualProduct.OrderId);
            Assert.AreEqual(expectedOrder.User.FirstName, actualProduct.User.FirstName);
            Assert.AreEqual(expectedOrder.User.LastName, actualProduct.User.LastName);
            Assert.AreEqual(expectedOrder.User.Phone, actualProduct.User.Phone);
            Assert.AreEqual(expectedOrder.OrderDate, actualProduct.OrderDate);
            Assert.AreEqual(expectedOrder.OrderCost, actualProduct.OrderCost);
            Assert.AreEqual(expectedOrder.Status, actualProduct.Status);
        }
    }
}
