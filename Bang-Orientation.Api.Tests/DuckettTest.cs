using System;
using System.Net;
using System.Net.Http;
using Bang_Orientation.Api.Controllers;
using Bang_Orientation.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Bang_Orientation.Api.DAL.Interface;
using System.Web.Http;
using Bang_Orientation.Api.DAL.Repository;

namespace Bang_Orientation.Api.Tests
{
    [TestClass]
    public class DuckettTest
    {
        DuckettController _controller;
        Mock<DuckettRepository> _mockedDuckettRepository;
        // [TestMethod]
        // public void TestMethod1()
        // {
        // }
        [TestInitialize]
        public void Initialize()
        {
            _mockedDuckettRepository = new Mock<DuckettRepository>();

            _controller = new DuckettController(_mockedDuckettRepository.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }

        [TestMethod]
        public void AddADuckettSuccessfully()
        {
            //arrange 
            var newDuckett = new Duckett
            {
                DuckettsId = 123456,
                DuckettsType = "American Express",
                AccountNumber = 654321,
                CustomerId = 123
            };

            //act
            var result = _controller.AddDuckett(newDuckett);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            //product gets saved to a repository
            _mockedDuckettRepository.Verify(x => x.Save(newDuckett));
        }

    }
}
