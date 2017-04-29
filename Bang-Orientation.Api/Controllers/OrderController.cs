using Bang_Orientation.Api.DAL.Repository;
using Bang_Orientation.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bang_Orientation.Api.Controllers
{
    public class OrderController : ApiController
    {
        public IOrderRepository _orderRepository;  // pulls "void Save(Order newOrder);" implimentation from IOrderRepository Interface


        public OrderController(IOrderRepository orderRepository)    // initiates use of the orderRepository through OrderController
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        [Route("api/order")]
        public HttpResponseMessage LogOrder(Order order)
        {
            if (string.IsNullOrWhiteSpace(order.OrderTitle))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Response");
            }
            _orderRepository.Save(order);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
