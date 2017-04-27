using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bang_Orientation.Api.Controllers;
using Bang_Orientation.Api.DAL.Interface;
using Bang_Orientation.Api.DAL.Repository;
using Bang_Orientation.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bang_Orientation.Api.Tests
{
    [TestClass]
    public class ProductTests
    {
        ProductController _controller;
        private Mock<IProductRepository> _mockedProductRepository;

        [TestInitialize]
        public void Initialize()
        {
            _mockedProductRepository = new Mock<IProductRepository>();

            _controller = new ProductController(_mockedProductRepository.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }

        [TestMethod]
        public void AddAProductSuccessfully()
        {
            //arrange 
            var newProduct = new Product
            {
                ProductId = 1,
                Name = "Wolverine Comic, No. 1",
                Brand = "Marvel Comics",
                Description = "Meet the unkillable Wolverine!",
                Price = 4.75
            };

            //act
            var result = _controller.AddProduct(newProduct);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            //product gets saved to a repository
            _mockedProductRepository.Verify(x => x.Save(newProduct));
        }
    }
}
