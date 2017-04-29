using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bang_Orientation.Api.DAL.Interface;
using Bang_Orientation.Api.DAL.Repository;
using Bang_Orientation.Api.Models;

namespace Bang_Orientation.Api.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]

        public HttpResponseMessage AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Product Name");
            }

            _productRepository.Save(product);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll()
        {
            var products = _productRepository.GetAllProducts();

            return Request.CreateResponse(HttpStatusCode.OK, products);
        }
        [HttpGet]
        [Route("{productId}")]
        public HttpResponseMessage GetSingleProduct(int productId)
        {

            var product = _productRepository.GetSingleProduct(productId);

            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        [HttpDelete]
        [Route("{productId}")]
        public HttpResponseMessage DeleteSingleProduct(int productId)
        {
            bool itWorked = _productRepository.DeleteSingleProduct(productId);

            return Request.CreateResponse(HttpStatusCode.OK, itWorked);
        }
    }
}


