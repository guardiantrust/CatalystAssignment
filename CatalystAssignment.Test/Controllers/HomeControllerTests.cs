using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalystAssignment.Controllers;
using CatalystAssignment.Interfaces.Reositories;
using CatalystAssignment.Test.Repositories;
using System.Web.Mvc;
using Newtonsoft.Json;
using CatalystAssignment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace CatalystAssignment.Test.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController _controller;
        private IPersonRepository _personRepo = new FakePersonRepository();
        [TestInitialize]
        public void Setup()
        {
            _controller = new HomeController(_personRepo);
        }

        [TestMethod]
        public void IndexTest()
        {
            //Arrange
            //Act
            var i = _controller.Index();

            //Assert
            Assert.IsTrue(i is ActionResult);
        }

        [TestMethod]
        public void SearchByNamePersonTest()
        {
            //Arrange
            //Act
            var json = _controller.SearchByName("d", 0);
            var serializer = new JavaScriptSerializer();
            var output = serializer.Serialize(json.Data);

            //Asssert
            Assert.IsTrue(output.Contains("Ted"));
            Assert.IsTrue(output.Contains("Nuggent"));
            Assert.IsTrue(output.Contains("Eddie"));
            Assert.IsTrue(output.Contains("Van Halen"));
        }
    }
}
