using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using AutoMapper;
using FacadeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using Npgsql.TypeMapping;
using ViewWindowsForms;
using Moq;
namespace UnitTestsFacade
{
    [TestClass]
    public class DBFacadeTests
    {
        private DBFacade _dbFacade;
        private string _connectionString = "Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway";

        [TestInitialize]
        public void Setup()
        {
            _dbFacade = DBFacade.GetInstance(_connectionString);
        }
        
        [TestMethod]
        public void GetProductList_ShouldReturnProducts()
        {
            // Act
            var products = _dbFacade.GetProductList();

            // Assert
            Assert.IsNotNull(products, "Список продуктов не должен быть null.");
            Assert.IsTrue(products.Count > 0, "Ожидается хотя бы один продукт.");
        }
        [TestMethod]
        public void TestCalcilateOrderNullCost()
        {
            // arrange
            int testUserId = 6;
            decimal expectedCost = 0;

            // act
            decimal cost = _dbFacade.CalculateOrderCost(testUserId);

            // assert
            Assert.AreEqual(expectedCost, cost);
        }
        [TestMethod]
        public void GetOrderListForEmployes_ShouldReturnOrders()
        {
            // Act
            var orders = _dbFacade.GetOrderListForEmployes();

            // Assert
            Assert.IsNotNull(orders, "Список заказов не должен быть null.");
            Assert.IsTrue(orders.Count > 0, "Ожидается хотя бы один заказ.");
        }
        [TestMethod]
        public void TestLoginCustomer()
        {
            // arrange
            string phone = "79132002020";
            string password = "123";

            // act
            User user = _dbFacade.Login(phone, password);

            // assert
            Assert.AreEqual("customer", user.role_name); 
        }
        [TestMethod]
        public void GetShipmentList_ShouldReturnListOfShipments()
        {
            // Act
            List<Shipment> shipments = _dbFacade.GetShipmentList();

            // Assert
            Assert.IsNotNull(shipments);
            Assert.IsFalse(shipments.Count > 0);
        }
        [TestMethod]
        public void GetOrderListForCustomer_ShouldReturnNonEmptyList()
        {
            // Arrange
            int userId = 6;

            // Act
            List<Order> orders = _dbFacade.GetOrderListForCustomer(userId);

            // Assert
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count > 0, "Список заказов не должен быть пустым");
        }
        [TestMethod]
        public void GetProductListInOrder_ShouldReturnNonEmptyList()
        {
            // Arrange
            int orderId = 41;

            // Act
            List<Product> products = _dbFacade.GetProductListInOrder(orderId);

            // Assert
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Count > 0);
        }
        [TestMethod]
        public void UpdateOrderStatus_ValidTransition_ShouldUpdate_ForWarehouser()
        {
            // Arrange
            int orderId = 42;
            string expectedNewStatus = "Собран";

            // Act
            string currentStatus = _dbFacade.GetOrderStatus(orderId);
            Assert.IsFalse(string.IsNullOrEmpty(currentStatus), "Текущий статус заказа не должен быть пустым.");

            _dbFacade.UpdateOrderStatus(orderId, expectedNewStatus, "warehouser");
            string newStatus = _dbFacade.GetOrderStatus(orderId);

            // Assert
            Assert.AreEqual(expectedNewStatus, newStatus, $"Статус заказа должен быть '{expectedNewStatus}'. Текущий статус: '{newStatus}'");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UpdateOrderStatus_InvalidTransition_ShouldThrow()
        {
            // Arrange
            int orderId = 41;
            string invalidNewStatus = "Выдан";

            // Act
            _dbFacade.UpdateOrderStatus(orderId, invalidNewStatus, "seller");
        }
    }
    [TestClass]
    public class FormSellerOrdersTests
    {
        private Mock<ISellerFacade> _mockDbFacade;
        private User _testUser;
        private FormSellerOrders _formSellerOrders;

        [TestInitialize]
        public void Setup()
        {
            _mockDbFacade = new Mock<ISellerFacade>();
            _testUser = new User { first_name = "Иван", last_name = "Иванов", role_name = "Продавец" };
            _formSellerOrders = new FormSellerOrders(_testUser, _mockDbFacade.Object);
        }

        [TestMethod]
        public void Constructor_NullUser_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new FormSellerOrders(null, _mockDbFacade.Object));
        }

        [TestMethod]
        public void Constructor_NullDbFacade_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new FormSellerOrders(_testUser, null));
        }
    }
    [TestClass]
    public class FormLoginTests
    {
        private readonly DBFacade _dbFacade;
        private User user;

        public FormLoginTests()
        {
            string connectionString = "Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway";
            _dbFacade = DBFacade.GetInstance(connectionString);
        }

        [TestMethod]
        public void Login_WithValidCredentials_ShouldReturnUser()
        {
            // Arrange
            string validPhone = "79132002020"; 
            string validPassword = "123"; 

            // Act
            User user = _dbFacade.Login(validPhone, validPassword);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(validPhone, user.phone); 
            Assert.AreEqual("customer", user.role_name);
        }

        [TestMethod]
        public void Login_WithInvalidCredentials_ShouldReturnNull()
        {
            // Arrange
            string validPhone = "79133003030";
            string validPassword = "123";

            // Act
            User user = _dbFacade.Login(validPhone, validPassword);

            // Assert
            Assert.AreNotEqual("customer", user.role_name);
        }
    }
}

