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
        public readonly NpgsqlConnection _connection; // нужно подумать 

        //public DBFacadeBase base;
        private DBFacade(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IDataRecord, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src["user_id"]))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src["first_name"]))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src["last_name"]))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src["phone"]))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src["user_password"]))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src["role_name"]));
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
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src["user_id"]))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src["order_date"]))
                .ForMember(dest => dest.OrderCost, opt => opt.MapFrom(src => src["order_cost"]))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src["status_name"]));
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
            catch(Exception ex)
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
        public void ExecuterNonQuery(string query,string exceptionText)
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
            ExecuterNonQuery(query,exceptionText);
        }
        public List<string> GetStatusList()
        {
            string query = "select status_name from statuses order by status_id asc";
            string textException = "Ошибка получения списка статусов";
            return ExecuterGetObjects<string>(query, textException);
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
            string query = $@"select order_id, first_name,last_name,phone,order_date,order_cost,status_name from orders
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
            string query = $@"select product_name, category_name, manufacturer, unit_price, condition_wholesale, 
                                discount, order_items.product_count from order_items
                                join products using (product_id)
                                join categories using (category_id)
                                where order_id = {order_id}";
            string textException = "Ошибка получения деталей заказа";
            return ExecuterGetObjects<Product>(query, textException);
        }
        public List<Product> GetProductsFromCart(int userId)
        {
            string query = $@"SELECT product_name, manufacturer, category_name, unit_price, condition_wholesale, discount, product_count 
                            FROM carts 
                            JOIN products USING(product_id)
                            JOIN categories USING(category_id)
                            where user_id={userId}";
            string textException = "Ошибка получения продуктов корзины";
            return ExecuterGetObjects<Product>(query, textException);
        }
        // Сомнительные методы надо еще подумать
        public List<Product> GetListProductAfterSort(string productName, string category, string manufacturer, bool inStock)
        {
            return new List<Product>();
        }
        public Product GetProduct()
        {
            return new Product();
        }
        public void SaveProductInCart(int user_id, int product_id)
        {
            try
            {
                string query = $@"INSERT INTO carts (user_id, product_id) values ({user_id}, {product_id})";
                using (var insertCommand = new NpgsqlCommand(query, _connection))
                {
                    insertCommand.Parameters.AddWithValue("@userId", user_id);
                    insertCommand.Parameters.AddWithValue("@productId", product_id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка добавления товара в корзину: {ex.Message}");
            }
        }
    }
}
