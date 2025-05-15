using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace FacadeLibrary
{
    public class DBFacade : ICustomerFacade, ISellerFacade, IWarehouserFacade
    {
        private static DBFacade instance;
        public readonly string connectionString = "Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway";
        private readonly NpgsqlConnection _connection;
        private DBFacade(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }
        public static DBFacade GetInstance(string connectionString)
        {
            if (instance == null)
                instance = new DBFacade(connectionString);
            return instance;
        }
        public string GetUserRole(string phone, string password)
        {
            try
            {
                string query = $@"select role_name from users 
                              join roles using(role_id)  
                              where phone = '{phone}' and user_password = '{password}'";

                using (var cmd = new NpgsqlCommand(query, _connection))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения роли пользователя: {ex.Message}");
                return null;
            }
        }
        public List<string> GetStatusList()
        {
            var statusList = new List<string>();

            try
            {
                string query = "select status_name from statuses";
                using (var cmd = new NpgsqlCommand(query, _connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        statusList.Add(reader.GetString(reader.GetOrdinal("status_name")));
                    }
                }
                return statusList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения списка статусов: {ex.Message}");
                return statusList;
            }
        }
        public List<Product> GetProductList()
        {
            List<Product> productList = new List<Product>();

            try
            {
                string query = @"SELECT product_name, manufacturer, category_name, unit_price, condition_wholesale, discount, product_count 
                                 FROM products 
                                 JOIN categories USING(category_id)";

                using (var cmd = new NpgsqlCommand(query, _connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            ProductName = reader.GetString(reader.GetOrdinal("product_name")),
                            Manufacturer = reader.GetString(reader.GetOrdinal("manufacturer")),
                            CategoryName = reader.GetString(reader.GetOrdinal("category_name")),
                            UnitPrice = reader.GetInt32(reader.GetOrdinal("unit_price")),
                            ConditionWholesale = reader.GetInt32(reader.GetOrdinal("condition_wholesale")),
                            Discount = reader.GetInt32(reader.GetOrdinal("discount")),
                            ProductCount = reader.GetInt32(reader.GetOrdinal("product_count"))
                        };
                        productList.Add(product);
                    }
                }
                return productList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения списка продуктов: {ex.Message}");
                return productList;
            }
        }
        public List<Order> GetOrderListForEmployes()
        {
            List<Order> orderList = new List<Order>();

            try
            {
                string query = $@"select order_id, first_name,last_name,phone,order_date,order_cost,status_name from orders
                                join users using (user_id)
                                join statuses using (status_id)";

                using (var cmd = new NpgsqlCommand(query, _connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order
                        {
                            OrderId = reader.GetInt32(reader.GetOrdinal("order_id")),
                            User = new User() 
                            { 
                                FirstName = reader.GetString(reader.GetOrdinal("first_name")), 
                                LastName = reader.GetString(reader.GetOrdinal("last_name")),
                                Phone = reader.GetString(reader.GetOrdinal("phone"))
                            },
                            OrderDate = reader.GetDateTime(reader.GetOrdinal("order_date")),
                            OrderCost = reader.GetDecimal(reader.GetOrdinal("order_cost")),
                            Status = reader.GetString(reader.GetOrdinal("status_name"))
                            
                        };
                        orderList.Add(order);
                    }
                }
                return orderList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения списка заказов: {ex.Message}");
                return orderList;
            }
        }
        public List<Product> GetDetailsCurrentOrder()
        {
            return null;
        }
    }
}
