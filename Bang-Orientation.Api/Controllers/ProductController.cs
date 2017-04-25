using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bang_Orientation.Api.DAL.Repository;
using Bang_Orientation.Api.Models;

namespace Bang_Orientation.Api.Controllers
{
    public class ProductController : ApiController
    {
        readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        [Route("api/product")]


        public HttpResponseMessage AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Product Name");
            }

            _productRepository.Save(product);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
}
