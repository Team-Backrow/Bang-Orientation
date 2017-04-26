using Bang_Orientation.Api.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bang_Orientation.Api.Models;


namespace Bang_Orientation.Api.Controllers
{
    [RoutePrefix("api/lineitem")]
    public class LineItemController : ApiController
    {
        readonly LineItemRepository _lineitemRepository;

    public LineItemController(LineItemRepository lineitemRepository)
    {
         _lineitemRepository = lineitemRepository;
    }

    [HttpPost]
    public HttpResponseMessage RegisterLineItem(LineItem lineitem)
    {
            if (string.IsNullOrWhiteSpace(lineitem.CustomerOrder))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid CustomerOrder");
            }

            _lineitemRepository.Save(lineitem);
            return Request.CreateResponse(HttpStatusCode.OK);
    }

    [HttpGet]
    public HttpResponseMessage GetAll()
        {
            var lineitem = _lineitemRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, lineitem);
        }

    //[HttpPut]
    //public HttpResponseMessage RegisterLineItem(LineItem lineitem)
      //  {
        //    var lineitem = _lineitemRepository.GetAll();
          //  return Request.CreateResponse(HttpStatusCode.OK, lineitem);
        //}

    }
    }

