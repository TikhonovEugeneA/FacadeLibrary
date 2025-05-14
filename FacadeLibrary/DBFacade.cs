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
                string query = $"select role_name from users " +
                              $"join roles using(role_id) " +
                              $"where phone = '{phone}' and user_password = '{password}'";

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
                        statusList.Add(reader.GetString(0));
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
    }
}
