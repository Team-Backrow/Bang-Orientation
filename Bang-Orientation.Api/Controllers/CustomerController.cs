using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bang_Orientation.Api.Models;

namespace Bang_Orientation.Api.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        readonly ICustomerRepository _customerRepository;

        public CustomerController()
        {
        }

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public HttpResponseMessage AddACustomer(Customer customer)
        {
            _customerRepository.Save(customer);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage GetACustomer(int id)
        {
            var oneCustomer = _customerRepository.GetACustomer(id);
            return Request.CreateResponse(HttpStatusCode.OK, oneCustomer);
        }

        [HttpGet]
        public HttpResponseMessage GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }
    }
}

  