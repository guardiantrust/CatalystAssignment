using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalystAssignment.Controllers;
using CatalystAssignment.Interfaces.Reositories;
using CatalystAssignment.Test.Repositories;
using System.Web.Mvc;
using System.Net.Http;
using Moq;
using System.Web;
using System.Collections.Generic;
using System.Web.Routing;
using System.Collections.Specialized;
using CatalystAssignment.Models;
using Newtonsoft.Json;
using System.IO;
using System.Drawing.Imaging;
using System.Web.Script.Serialization;

namespace CatalystAssignment.Test.Controllers
{
    [TestClass]
    public class PersonControllerTests
    {
        private PersonController _controller;
        private IPersonRepository _personRepo = new FakePersonRepository();

        [TestInitialize]
        public void Setup()
        {
            _controller = new PersonController(_personRepo);
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
        public void InsertPersonTest()
        {
            //Arrange
            using (MemoryStream pictureStream = new MemoryStream())
            {
                var httpContextMock = new Mock<HttpContextBase>();
                var httpRequestMock = new Mock<HttpRequestBase>();
                var httpFileUploadMock = new Mock<HttpPostedFileBase>();
                Properties.Resources.me.Save(pictureStream, ImageFormat.Jpeg);
                httpFileUploadMock.SetupGet(x => x.InputStream).Returns(pictureStream);
                httpFileUploadMock.SetupGet(x => x.ContentLength).Returns((int)pictureStream.Length);

                var person = new PersonViewModel
                {
                    FirstName = "Aaron",
                    LastName = "Peterson",
                    Intrests = "SOLID Programming",
                    DOB = new DateTime(1979, 07, 04)
                };

                var newPerson = new NameValueCollection();
                newPerson["newPerson"] = JsonConvert.SerializeObject(person);

                httpRequestMock.SetupGet(x => x.Form).Returns(newPerson);
                httpRequestMock.SetupGet(x => x.Files.AllKeys).Returns(new string[] { "picture" });
                httpRequestMock.SetupGet(x => x.Files["picture"]).Returns(httpFileUploadMock.Object);

                httpContextMock.SetupGet(c => c.Request).Returns(httpRequestMock.Object);
                _controller.ControllerContext = new ControllerContext(httpContextMock.Object, new RouteData(), _controller);

                //Act
                var id =  _controller.InsertPerson().Result;

                //Assert
                var serializer = new JavaScriptSerializer();
                var output = serializer.Serialize(id.Data);
                Assert.IsTrue(Convert.ToInt32(output) != -1);
            }
        }
    }
}
