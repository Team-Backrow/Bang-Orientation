using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bang_Orientation.Api.Controllers;
using Bang_Orientation.Api.DAL.Repository;
using Moq;
using System.Net.Http;
using System.Web.Http;
using Bang_Orientation.Api.Models;
using System.Net;

namespace Bang_Orientation.Api.Tests
{
    [TestClass]
    public class OrderTests
    {
            OrderController _controller;
            Mock<IOrderRepository> _mockedOrderRepository;

            [TestInitialize]
        public void Initialize()
        {
            _mockedOrderRepository = new Mock<IOrderRepository>();

            _controller = new OrderController(_mockedOrderRepository.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }

        [TestMethod]
        public void LogOrderSuccessfully()
        {
            //Arrange

            var newOrder = new Order
            {
                OrderTitle = "First Order",
                OrderID = 1234,
                CustomerID = 1234,
                DuckettsID = 1234
            };


            //Act
            var result = _controller.LogOrder(newOrder);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            _mockedOrderRepository.Verify(x => x.Save(newOrder));
        }

        [TestMethod]
        public void NoNewOrderTitleShouldFail()
        {
            var newOrder = new Order
            {
                OrderTitle = "",
                OrderID = 1234,
                CustomerID = 1234,
                DuckettsID = 1234
                
            };

            var result = _controller.LogOrder(newOrder);

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            _mockedOrderRepository.Verify(x => x.Save(It.IsAny<Order>()), Times.Never);
        }

    }
}
