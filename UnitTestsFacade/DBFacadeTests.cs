using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FacadeLibrary;
using System.Collections.Generic;

namespace UnitTestsFacade
{
    [TestClass]
    public class DBFacadeTests
    {
        [TestMethod]
        public void TestGetUserRole()
        {
            DBFacade dBFacade = DBFacade.GetInstance("Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway");
            var value = dBFacade.GetUserRole("79131001010", "123");
            var trueValue = "admin";
            Assert.AreEqual(trueValue,value);
        }
        [TestMethod]
        public void TestGetStatusList()
        {
            DBFacade dBFacade = DBFacade.GetInstance("Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway");
            var value = dBFacade.GetStatusList();
            var trueValue = new List<string>(){"Принят","В сборке","Собран","Запрошен","Передан","Выдан","Возврат","Разобран"};
            Assert.AreEqual(trueValue[0], value[0]);
        }
    }
}
