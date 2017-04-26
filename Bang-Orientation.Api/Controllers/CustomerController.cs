using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bang_Orientation.Api.Models;

namespace Bang_Orientation.Api.Controllers
{
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
        [Route("api/customer")]
        public HttpResponseMessage AddACustomer(Customer customer)
        {
            _customerRepository.Save(customer);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
