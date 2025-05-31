using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Npgsql.TypeMapping;
using AutoMapper;

namespace FacadeLibrary
{
    public class DBFacade : ICustomerFacade, ISellerFacade, IWarehouserFacade
    {
        public static DBFacade instance;
        private readonly IMapper mapper;
        public readonly string connectionString = "Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway";
        public readonly NpgsqlConnection _connection;

        private DBFacade(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IDataRecord, User>()
                .ForMember(dest => dest.user_id, opt => opt.MapFrom(src => src["user_id"]))
                .ForMember(dest => dest.first_name, opt => opt.MapFrom(src => src["first_name"]))
                .ForMember(dest => dest.last_name, opt => opt.MapFrom(src => src["last_name"]))
                .ForMember(dest => dest.phone, opt => opt.MapFrom(src => src["phone"]))
                .ForMember(dest => dest.user_password, opt => opt.MapFrom(src => src["user_password"]))
                .ForMember(dest => dest.role_name, opt => opt.MapFrom(src => src["role_name"]));
                cfg.CreateMap<IDataRecord, Product>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src["product_id"]))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src["product_name"]))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src["manufacturer"]))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src["category_name"]))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src["unit_price"]))
                .ForMember(dest => dest.ConditionWholesale, opt => opt.MapFrom(src => src["condition_wholesale"]))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src["discount"]))
                .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src["product_count"]));
                cfg.CreateMap<IDataRecord, Order>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src["order_id"]))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src["last_name"]))
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src["first_name"]))
                .ForMember(dest => dest.UserPhone, opt => opt.MapFrom(src => src["phone"]))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src["order_date"]))
                .ForMember(dest => dest.OrderCost, opt => opt.MapFrom(src => src["order_cost"]))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src["status_name"]));
                cfg.CreateMap<IDataRecord, Cart>()
                .ForMember(dest => dest.product_id, opt => opt.MapFrom(src => src["product_id"]))
                .ForMember(dest => dest.product_name, opt => opt.MapFrom(src => src["product_name"]))
                .ForMember(dest => dest.manufacturer, opt => opt.MapFrom(src => src["manufacturer"]))
                .ForMember(dest => dest.category_name, opt => opt.MapFrom(src => src["category_name"]))
                .ForMember(dest => dest.unit_price, opt => opt.MapFrom(src => src["unit_price"]))
                .ForMember(dest => dest.condition_wholesale, opt => opt.MapFrom(src => src["condition_wholesale"]))
                .ForMember(dest => dest.discount, opt => opt.MapFrom(src => src["discount"]))
                .ForMember(dest => dest.product_count, opt => opt.MapFrom(src => src["product_count"]))
                .ForMember(dest => dest.product_count_in_cart, opt => opt.MapFrom(src => src["product_count_in_cart"]));
                cfg.CreateMap<IDataRecord, Shipment>()
                .ForMember(dest => dest.product_name, opt => opt.MapFrom(src => src["product_name"]))
                .ForMember(dest => dest.manufacturer, opt => opt.MapFrom(src => src["manufacturer"]))
                .ForMember(dest => dest.category, opt => opt.MapFrom(src => src["category"]))
                .ForMember(dest => dest.company_name, opt => opt.MapFrom(src => src["company_name"]))
                .ForMember(dest => dest.shipment_date, opt => opt.MapFrom(src => src["shipment_date"]))
                .ForMember(dest => dest.product_count, opt => opt.MapFrom(src => src["product_count"]));
                cfg.CreateMap<IDataRecord, Status>()
                .ForMember(dest => dest.status_name, opt => opt.MapFrom(src => src["status_name"]));
            });
            mapper = configuration.CreateMapper();
        }
        public static DBFacade GetInstance(string connectionString)
        {
            if (instance == null)
                instance = new DBFacade(connectionString);
            return instance;
        }
        public List<T> ExecuterGetObjects<T>(string query, string exceptionText)
        {
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, _connection))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    List<T> modelObjectList = new List<T>();
                    while (reader.Read())
                    {
                        T _modelObject = mapper.Map<T>(reader);
                        modelObjectList.Add((_modelObject));
                    }
                    return modelObjectList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{exceptionText} по причине: {ex.Message}");
            }
        }
        public T ExecuterGetObject<T>(string query, string exceptionText)
        {
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    T _modelObject = mapper.Map<T>(reader);
                    return _modelObject;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{exceptionText} по причине: {ex.Message}");
            }
        }
        public void ExecuterNonQuery(string query, string exceptionText)
        {
            try
            {
                using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{exceptionText} по причине: {ex.Message}");
            }
        }
        public User Login(string phone, string password)
        {
            string query = $@"select user_id,first_name,last_name,phone,user_password,role_name from users
                                join roles using(role_id)
                                where phone = '{phone}' and user_password = '{password}'";
            string exceptionText = "Ошибка входа";
            return ExecuterGetObject<User>(query, exceptionText);
        }
        public void RegistrationCustomer(string firstName, string lastName, string phone, string password)
        {
            string query = $@"insert into users (first_name,last_name,phone,user_password,role_id) 
                                values ('{firstName}','{lastName}','{phone}','{password}',
                                (select role_id from roles where role_name = 'customer'))";
            string exceptionText = "Ошибка регистрации";
            ExecuterNonQuery(query, exceptionText);
        }
        public List<Status> GetStatusList()
        {
            string query = "select status_name from statuses order by status_id asc";
            string textException = "Ошибка получения списка статусов";
            return ExecuterGetObjects<Status>(query, textException);
        }
        public List<Product> GetProductList()
        {
            string query = @"select product_id,product_name, manufacturer, category_name, unit_price, condition_wholesale, discount, product_count 
                           from products 
                           join categories using(category_id)
                           order by product_id asc";
            string textException = "Ошибка получения списка продуктов";
            return ExecuterGetObjects<Product>(query, textException);
        }
        public List<Order> GetOrderListForEmployes()
        {
            string query = $@"select order_id,last_name,first_name,phone,order_date,order_cost,status_name from orders
                            join users using (user_id)
                            join statuses using (status_id)";
            string textException = "Ошибка получения списка заказов";
            return ExecuterGetObjects<Order>(query, textException);
        }
        public List<Order> GetOrderListForCustomer(int user_id)
        {
            string query = $@"select order_id, first_name,last_name,phone,order_date,order_cost,status_name from orders
                            join users using (user_id)
                            join statuses using (status_id)
                            where user_id = {user_id}";
            string textException = "Ошибка получения списка заказов";
            return ExecuterGetObjects<Order>(query, textException);
        }
        public List<Product> GetProductListInOrder(int order_id)
        {
            string query = $@"select product_id, product_name, category_name, manufacturer, unit_price, condition_wholesale, 
                                discount, order_items.product_count from order_items
                                join products using (product_id)
                                join categories using (category_id)
                                where order_id = {order_id}";
            string textException = "Ошибка получения деталей заказа";
            return ExecuterGetObjects<Product>(query, textException);
        }
        public List<Cart> GetProductsFromCart(int userId)
        {
            string query = $@"SELECT product_id, product_name, manufacturer, category_name, unit_price, condition_wholesale, discount, product_count_in_cart, product_count 
                            FROM carts 
                            JOIN products USING(product_id)
                            JOIN categories USING(category_id)
                            where user_id={userId}";
            string textException = "Ошибка получения продуктов корзины";
            return ExecuterGetObjects<Cart>(query, textException);
        }
        public void SaveProductInCart(int userId, int productId)
        {
            string query = $@"INSERT INTO carts (user_id, product_id, product_count_in_cart) values ({userId}, {productId}, 1)";
            string exceptionText = "Ошибка добавления товара в корзину по причине";
            ExecuterNonQuery(query, exceptionText);
        }
        public void DeleteProductFromCart(int userId, int productId)
        {
            string query = $@"delete from carts where user_id = {userId} and product_id = {productId}";
            string exceptionText = "Ошибка удаления товара из корзины по причине";
            ExecuterNonQuery(query, exceptionText);
        }
        public void ClearCartAfterCalculateOrderCost(int userId)
        {
            string query = $"delete from carts where user_id = {userId}";
            string exceptionText = "Ошибка очистки корзины после оформления заказа";
            ExecuterNonQuery(query, exceptionText);
        }
        public void UpdateProductCountInCart(int userId, int productId, int newCount)
        {
            string query;

            if (newCount == 0)
                query = $@"DELETE FROM carts WHERE user_id = {userId} AND product_id = {productId}";
            else
                query = $@"UPDATE carts SET product_count_in_cart = {newCount} WHERE user_id = {userId} AND product_id = {productId}";

            string exceptionText = "Ошибка обновления количества товара в корзине";
            ExecuterNonQuery(query, exceptionText);
        }
        public decimal CalculateOrderCost(int userId)
        {
            List<Cart> products = GetProductsFromCart(userId);
            decimal total = 0;

            foreach (var product in products)
            {
                decimal pricePerItem = product.unit_price;
                decimal discount = 0;

                if (product.condition_wholesale <= product.product_count_in_cart && product.discount > 0)
                {
                    discount = product.unit_price * (product.discount / 100m);
                    pricePerItem = product.unit_price - discount;
                }
                total += pricePerItem * product.product_count_in_cart;
            }

            return total;
        }
        public int CreateOrder(int userId, List<int> productIds, List<int> productCounts)
        {
            if (productIds.Count != productCounts.Count)
            {
                throw new ArgumentException("Количество продуктов и их количеств должно совпадать.");
            }

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    int orderId;
                    decimal totalCost = CalculateOrderCost(userId);

                    var orderQuery = @"
                INSERT INTO orders (user_id, order_cost, status_id, order_date)
                VALUES (@userId, @totalCost, 1, @orderDate)
                RETURNING order_id";

                    using (var cmd = new NpgsqlCommand(orderQuery, _connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@totalCost", totalCost);
                        cmd.Parameters.AddWithValue("@orderDate", DateTime.Now);
                        orderId = (int)cmd.ExecuteScalar();
                    }

                    var itemsQuery = @"
                INSERT INTO order_items (order_id, product_id, product_count)
                VALUES (@orderId, @productId, @count)";

                    for (int i = 0; i < productIds.Count; i++)
                    {
                        using (var cmd = new NpgsqlCommand(itemsQuery, _connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@orderId", orderId);
                            cmd.Parameters.AddWithValue("@productId", productIds[i]);
                            cmd.Parameters.AddWithValue("@count", productCounts[i]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return orderId;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public List<Shipper> GetShippers()
        {
            var shippers = new List<Shipper>();
            string query = "SELECT shipper_id, company_name FROM shippers ORDER BY company_name";

            using (var cmd = new NpgsqlCommand(query, _connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    shippers.Add(new Shipper
                    {
                        ShipperId = reader.GetInt32(0),
                        CompanyName = reader.GetString(1)
                    });
                }
            }

            return shippers;
        }
        public List<Shipment> GetShipmentList()
        {
            string query = @"
        SELECT 
            p.product_id,
            p.product_name,
            c.category_name AS category,
            p.manufacturer,
            s.company_name,
            sh.shipment_date,
            si.product_count
        FROM shipment_items si
        JOIN shipments sh ON si.shipment_id = sh.shipment_id
        JOIN products p ON si.product_id = p.product_id
        JOIN categories c ON p.category_id = c.category_id
        JOIN shippers s ON sh.shipper_id = s.shipper_id
        ORDER BY sh.shipment_date DESC;";

            string exceptionText = "Ошибка получения списка поставок";
            return ExecuterGetObjects<Shipment>(query, exceptionText);
        }
        public void AddShipment(int productId, int shipperId, int productCount)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    // 1. Вставляем новую поставку и получаем shipment_id
                    string insertShipmentQuery = @"
                INSERT INTO shipments (shipper_id, shipment_date)
                VALUES (@shipperId, @shipmentDate)
                RETURNING shipment_id;
            ";

                    int shipmentId;
                    using (var cmd = new NpgsqlCommand(insertShipmentQuery, _connection))
                    {
                        cmd.Parameters.AddWithValue("@shipperId", shipperId);
                        cmd.Parameters.AddWithValue("@shipmentDate", DateTime.Now.Date);
                        shipmentId = (int)cmd.ExecuteScalar();
                    }

                    // 2. Вставляем позицию поставки
                    string insertItemQuery = @"
                INSERT INTO shipment_items (shipment_id, product_id, product_count)
                VALUES (@shipmentId, @productId, @productCount);
            ";

                    using (var cmd = new NpgsqlCommand(insertItemQuery, _connection))
                    {
                        cmd.Parameters.AddWithValue("@shipmentId", shipmentId);
                        cmd.Parameters.AddWithValue("@productId", productId);
                        cmd.Parameters.AddWithValue("@productCount", productCount);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public string GetOrderStatus(int orderId)
        {
            string query = $@"SELECT status_name FROM orders 
            JOIN statuses USING(status_id) 
            WHERE order_id = {orderId}";

            using (NpgsqlCommand cmd = new NpgsqlCommand(query, _connection))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            return null;
        }
        public void UpdateOrderStatus(int orderId, string newStatus, string role)
        {
            Dictionary<string, Dictionary<string, bool>> allowedTransitions = new Dictionary<string, Dictionary<string, bool>>();

            if (role == "customer")
            {
                allowedTransitions = new Dictionary<string, Dictionary<string, bool>>
                {
                    { "Принят", new Dictionary<string, bool> { { "Отменен", true } } }
                };
            }
            if (role == "seller")
            {
                allowedTransitions = new Dictionary<string, Dictionary<string, bool>>
                {
                    { "Собран", new Dictionary<string, bool> { { "Запрошен", true } } },
                    { "Запрошен", new Dictionary<string, bool> { { "Передан", true } } },
                    { "Передан", new Dictionary<string, bool> { { "Выдан", true }, { "Возврат", true } } }
                };
            }
            if (role == "warehouser")
            {
                allowedTransitions = new Dictionary<string, Dictionary<string, bool>>
                {
                    { "Принят", new Dictionary<string, bool> { { "В сборке", true } } },
                    { "В сборке", new Dictionary<string, bool> { { "Собран", true } } },
                    { "Возврат", new Dictionary<string, bool> { { "Разобран", true } } }
                };
            }

            string currentStatus = GetOrderStatus(orderId);

            if (!allowedTransitions.ContainsKey(currentStatus) ||
                !allowedTransitions[currentStatus].ContainsKey(newStatus))
            {
                throw new InvalidOperationException($"Недопустимый переход статуса с '{currentStatus}' на '{newStatus}' для роли '{role}'");
            }

            string query = $@"UPDATE orders 
            SET status_id = (SELECT status_id FROM statuses WHERE status_name = '{newStatus}')
            WHERE order_id = {orderId}";

            ExecuterNonQuery(query, $"Ошибка изменения статуса заказа на {newStatus}");
        }
    }
}
