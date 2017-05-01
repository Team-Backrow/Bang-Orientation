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

        [HttpGet]
        [Route("api/order/{id}")]
        public HttpResponseMessage GetOrder(int id)
        {
            var order = _orderRepository.GetSingleOrder(id);

            if (order == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    $"The Order with an id of {id} does not exist");
            }

            return Request.CreateResponse(HttpStatusCode.OK, order);
        }
        
        [HttpGet]
        [Route("api/order")]
        public HttpResponseMessage ReturnAllOrders(Order order)
        {
           var allOrders = _orderRepository.AllOrders();

            return Request.CreateResponse(HttpStatusCode.OK, allOrders);
        }

        [HttpDelete]
        [Route("api/order/{id}")]
        public HttpResponseMessage DeleteOrder(int id)
        {
            var deleteOrder = _orderRepository.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK, deleteOrder);
        }

        [HttpPut]
        [Route("api/order/{id}")]
        public HttpResponseMessage EditOrder([FromBody] Order updatedOrder)
        {
            _orderRepository.Edit(updatedOrder);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
