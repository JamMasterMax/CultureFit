using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZipHackathon.Models.Request;
using ZipHackathon.Models.Response;
using ZipHackathon.Services;

namespace ZipHackathon.Controllers.Api
{
    [RoutePrefix("api/reviews")]
    public class ReviewsApiController : ApiController
    {
        [Route(), HttpPost]
        public HttpResponseMessage Create(ReviewCreateRequest review)
        {
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = ReviewService.Create(review);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }       
    }
}
