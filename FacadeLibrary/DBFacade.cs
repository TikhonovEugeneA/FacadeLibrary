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
        // надо подумать нужен ли метод GetUserRole если есть уже метод Login
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
        public User Login(string phone, string password)
        {
            try
            {
                string query = $@"select user_id,first_name,last_name,phone,role_name from users
                                join roles using(role_id)
                                where phone = '{phone}' and user_password = '{password}'";

                using (var cmd = new NpgsqlCommand(query, _connection))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("user_id")),
                            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                            LastName = reader.GetString(reader.GetOrdinal("last_name")),
                            Phone = reader.GetString(reader.GetOrdinal("phone")),
                            Role = reader.GetString(reader.GetOrdinal("role_name"))
                        };
                    }
                }
                return new User();
            }
            catch (Exception ex) 
            {
                throw new Exception($"Ошибка входа: {ex.Message}");
            }
        }
        public void RegistrationCustomer(string firstName,string lastName, string phone, string password)
        {
            try
            {
                string query = $@"insert into users (first_name,last_name,phone,user_password,role_id) 
                                values ('{firstName}','{lastName}','{phone}','{password}',
                                (SELECT role_id FROM roles WHERE role_name = 'customer'))";

                using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка регистрации: {ex.Message}");
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
        public List<Order> GetOrderListForCustomer(int user_id)
        {
            List<Order> orderList = new List<Order>();

            try
            {
                string query = $@"select order_id, first_name,last_name,phone,order_date,order_cost,status_name from orders
                                join users using (user_id)
                                join statuses using (status_id)
                                where user_id = {user_id}";

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
        public List<Product> GetProductListInOrder(int order_id)
        {
            List<Product> productListInOrder = new List<Product>();

            try
            {
                string query = $@"select product_name, category_name, manufacturer, unit_price, condition_wholesale, 
                                discount, order_items.product_count from order_items
                                join products using (product_id)
                                join categories using (category_id)
                                where order_id = {order_id}";

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
                        productListInOrder.Add(product);
                    }
                }
                return productListInOrder;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения списка заказов: {ex.Message}");
                return productListInOrder;
            }
        }


        // Сомнительные методы надо еще подумать
        public void SaveProductInCart(int user_id,int product_id)
        {
            try
            {
                string insertQuery = $@"INSERT INTO carts (user_id, product_id) values ({user_id}, {product_id})";
                using (var insertCommand = new NpgsqlCommand(insertQuery, _connection))
                {
                    insertCommand.Parameters.AddWithValue("@userId", user_id);
                    insertCommand.Parameters.AddWithValue("@productId", product_id);
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"Ошибка получения роли пользователя: {ex.Message}");
            }
        }
        public bool AddProductInCart(int userId, int productId)
        {
            try
            {
                string checkQuery = "select 1 from carts where user_id = @userId and product_id = @productId";

                bool productExists;
                using (var checkCmd = new NpgsqlCommand(checkQuery, _connection))
                {
                    checkCmd.Parameters.AddWithValue("@userId", userId);
                    checkCmd.Parameters.AddWithValue("@productId", productId);
                    productExists = checkCmd.ExecuteScalar() != null;
                }
                if (productExists)
                {
                    Console.WriteLine("Товар уже находится в корзине");
                    return false;
                }
                string insertQuery = @"insert carts (user_id, product_id) values (@userId, @productId)";

                using (var insertCmd = new NpgsqlCommand(insertQuery, _connection))
                {
                    insertCmd.Parameters.AddWithValue("@userId", userId);
                    insertCmd.Parameters.AddWithValue("@productId", productId);

                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении товара в корзину: {ex.Message}");
                return false;
            }
        }
    }
}
