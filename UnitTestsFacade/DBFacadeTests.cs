using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    }
}
