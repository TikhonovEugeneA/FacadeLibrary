using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacadeLibrary;

namespace ViewConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBFacade dBFacade = DBFacade.GetInstance("Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway");
            dBFacade.GetUserRole("79131001010", "123");
        }
    }
}
