using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bang_Orientation.Api.Controllers;
using Bang_Orientation.Api.DAL.Interface;
using Bang_Orientation.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bang_Orientation.Api.Tests
{
    [TestClass]
    public class ProductRetrievalTests
    {
        Mock<IProductRepository> _mockedProductRepository;
        ProductController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mockedProductRepository = new Mock<IProductRepository>();

            _controller = new ProductController(_mockedProductRepository.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }
        [TestMethod]
        public void ReturnAllProductsReturnsAllProducts()
        {
            //arrange
            _mockedProductRepository.Setup(x => x.GetAllProducts())
                .Returns(() =>
                    new List<Product>
                    {
                        new Product {Name = "Jimmy"},
                        new Product {Name = "Steve"},
                        new Product {Name = "Sally"}
                    });

            //act
            var result = _controller.GetAll();

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var content = result.Content as ObjectContent<IEnumerable<Product>>;
            var returnValue = content.Value as IEnumerable<Product>;
            Assert.AreEqual(3, returnValue.Count());
        }
    }
 }

