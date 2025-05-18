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
        public string connectionString = "Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway";

        [TestMethod]
        public void TestGetUserRole()
        {
            DBFacade dBFacade = DBFacade.GetInstance(connectionString);
            string value = dBFacade.GetUserRole("79131001010", "123");
            string trueValue = "admin";
            Assert.AreEqual(trueValue,value);
        }

        [TestMethod]
        public void TestLogin()
        {
            DBFacade dbFacade = DBFacade.GetInstance(connectionString);
            User value = dbFacade.Login("79132002020","123");
            string trueValue = "customer";
            Assert.AreEqual(trueValue,value.Role);
        }

        [TestMethod]
        public void TestGetStatusList()
        {
            DBFacade dBFacade = DBFacade.GetInstance(connectionString);
            List<string> value = dBFacade.GetStatusList();
            List<string> trueValue = new List<string>(){"Принят","В сборке","Собран","Запрошен","Передан","Выдан","Возврат","Разобран"};
            CollectionAssert.AreEqual(trueValue, value);
        }

        [TestMethod]
        public void TestGetProductList()
        {
            DBFacade dBFacade = DBFacade.GetInstance(connectionString);
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

            CollectionAssert.Contains(actualProducts, expectedProduct);
        }

        [TestMethod]
        public void TestGetOrdertListForEmployes()
        {
            DBFacade dBFacade = DBFacade.GetInstance(connectionString);
            Order expectedOrder1 = new Order()
            {
                OrderId = 7,
                User = new User()
                {
                    FirstName = "Петр",
                    LastName = "Петров",
                    Phone = "79132002020"
                },
                OrderDate = new DateTime(2025, 05, 15),
                OrderCost = 54915.00M,
                Status = "Принят"
            };
            Order expectedOrder2 = new Order()
            {
                OrderId = 8,
                User = new User()
                {
                    FirstName = "Петр",
                    LastName = "Петров",
                    Phone = "79132002020"
                },
                OrderDate = new DateTime(2025, 05, 16),
                OrderCost = 22000.00M,
                Status = "Собран",
            };
            List<Order> expectedOrderList = new List<Order>() {expectedOrder1,expectedOrder2};

            List<Order> actualOrders = dBFacade.GetOrderListForEmployes();

            var actualOrder1 = actualOrders.FirstOrDefault(o => o.OrderId == 7);
            Assert.IsNotNull(actualOrder1, "Заказ с ID=7 не найден");
            Assert.AreEqual("Петр", actualOrder1.User.FirstName);
            Assert.AreEqual(new DateTime(2025, 05, 15), actualOrder1.OrderDate.Date);
            Assert.AreEqual(54915.00M, actualOrder1.OrderCost, 0.01M);

            var actualOrder2 = actualOrders.FirstOrDefault(o => o.OrderId == 8);
            Assert.IsNotNull(actualOrder2, "Заказ с ID=8 не найден");
            Assert.AreEqual("Собран", actualOrder2.Status);
        }

        [TestMethod]
        public void TestGetOrdertListForCustomers()
        {
            DBFacade dBFacade = DBFacade.GetInstance(connectionString);
            Order expectedOrder1 = new Order()
            {
                OrderId = 7,
                User = new User()
                {
                    FirstName = "Петр",
                    LastName = "Петров",
                    Phone = "79132002020"
                },
                OrderDate = new DateTime(2025, 05, 15),
                OrderCost = 54915.00M,
                Status = "Принят"
            };
            Order expectedOrder2 = new Order()
            {
                OrderId = 8,
                User = new User()
                {
                    FirstName = "Петр",
                    LastName = "Петров",
                    Phone = "79132002020"
                },
                OrderDate = new DateTime(2025, 05, 16),
                OrderCost = 22000.00M,
                Status = "Собран",
            };
            List<Order> expectedOrderList = new List<Order>() { expectedOrder1, expectedOrder2 };

            List<Order> actualOrders = dBFacade.GetOrderListForCustomer(6);

            var actualOrder1 = actualOrders.FirstOrDefault(o => o.OrderId == 7);
            Assert.IsNotNull(actualOrder1, "Заказ с ID=7 не найден");
            Assert.AreEqual("Петр", actualOrder1.User.FirstName);
            Assert.AreEqual(new DateTime(2025, 05, 15), actualOrder1.OrderDate.Date);
            Assert.AreEqual(54915.00M, actualOrder1.OrderCost, 0.01M);

            var actualOrder2 = actualOrders.FirstOrDefault(o => o.OrderId == 8);
            Assert.IsNotNull(actualOrder2, "Заказ с ID=8 не найден");
            Assert.AreEqual("Собран", actualOrder2.Status);
        }

        [TestMethod]
        public void TestGetProductListInOrder()
        {
            DBFacade dBFacade = DBFacade.GetInstance(connectionString);
            Product expectedProduct = new Product()
            {
                ProductName = "Шуруповерт",
                Manufacturer = "Bosch",
                CategoryName = "Инструменты",
                UnitPrice = 12500,
                ConditionWholesale = 3,
                Discount = 5,
                ProductCount = 22
            };
            List<Product> actualProducts = dBFacade.GetProductListInOrder(7);

            CollectionAssert.Contains(actualProducts, expectedProduct);
        }
    }
}
