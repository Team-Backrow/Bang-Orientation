using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bang_Orientation.Api.Controllers;
using Bang_Orientation.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bang_Orientation.Api.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private CustomerController _controller;
        private Mock<ICustomerRepository> _mockedCustomerRepository;

        [TestInitialize]
        public void Initialize()
        {
            _mockedCustomerRepository = new Mock<ICustomerRepository>();

            _controller = new CustomerController(_mockedCustomerRepository.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }
        [TestMethod]
        public void AddNewCustomer()
        {
            //Arrange
            var controller = new CustomerController();
            var newCustomer = new Customer
            {
                Username = "FerrisMewler",
                FirstName = "Ferris",
                LastName = "Mewler",
                Password = "ImACatDuh"
            };

            //Act
            var result = _controller.AddACustomer(newCustomer);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            _mockedCustomerRepository.Verify(x=> x.Save(newCustomer));
        }
    }
}
