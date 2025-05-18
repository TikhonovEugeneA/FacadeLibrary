using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FacadeLibrary;

namespace ViewConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerFacade customerFacade = DBFacade.GetInstance("Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway");
            ISellerFacade sellerFacade = DBFacade.GetInstance("Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway");
            User user = new User();
            bool input = true;
            Console.WriteLine("1. Войти");
            Console.WriteLine("2. Зарегистрироваться");
            while (input)
            {
                string graph=Console.ReadLine();
                switch (graph)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Вход");
                        Console.WriteLine("Введите номер телефона:");
                        user.Phone=Console.ReadLine();
                        Console.WriteLine("Введите пароль:");
                        user.Password=Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Зарегистрироваться");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Введены неверные данные");
                        break;
                }
            }
        }
    }
}
