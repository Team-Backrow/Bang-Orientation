using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bang_Orientation.Api.DAL.Repository;
using Bang_Orientation.Api.Models;

namespace Bang_Orientation.Api.Controllers
{
    //[RoutePrefix("api/duckett")]
    public class DuckettController : ApiController
    {
        public new HttpRequestMessage Request;
        readonly DuckettRepository _duckettRepository;

        public DuckettController(DuckettRepository duckettRepository)
        {
            _duckettRepository = duckettRepository;
        }

        [HttpPost]
        [Route("api/duckett")]
        public HttpResponseMessage AddDuckett(Duckett duckett)
        {
            if (string.IsNullOrWhiteSpace(duckett.DuckettsType))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Payment (Duckett)");
            }

            _duckettRepository.Save(duckett);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
