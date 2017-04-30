using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bang_Orientation.Api.DAL.Interface;
using Bang_Orientation.Api.DAL.Repository;
using Bang_Orientation.Api.Models;

namespace Bang_Orientation.Api.Controllers
{
    public class DuckettController : ApiController
    {
 
        public IDuckettInterface _duckettRepository;
        public DuckettController(IDuckettInterface duckettRepository)
        {
            _duckettRepository = duckettRepository;

        }

        [HttpPost]
        [Route("api/duckett")]
        public HttpResponseMessage AddDuckett(Duckett duckett)
        {
            if (string.IsNullOrWhiteSpace(duckett.DuckettType))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Payment");
            }

            _duckettRepository.Save(duckett);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/duckett/{id}")]
        public HttpResponseMessage GetDuckett(int id)
        {
            var duckett = _duckettRepository.GetById(id);

            if (duckett == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    $"The Apple with an id of {id} does not exist");
            }

            return Request.CreateResponse(HttpStatusCode.OK, duckett);
        }

    }
}
