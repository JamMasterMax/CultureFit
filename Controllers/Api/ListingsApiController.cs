using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZipHackathon.Domain;
using ZipHackathon.Models.Request;
using ZipHackathon.Models.Response;
using ZipHackathon.Services;

namespace ZipHackathon.Controllers.Api
{
    [RoutePrefix("api/listings")]
    public class ListingsApiController : ApiController
    {
        [Route(), HttpGet]
        public HttpResponseMessage GetAll()
        {
            ItemsResponse<Listing> resp = new ItemsResponse<Listing>();
            List<Listing> listing = ListingsService.GetAll();

            resp.Items = listing;

            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }

        [Route(), HttpPost]
        public HttpResponseMessage Create(ListingCreateRequest model)
        {
            ItemResponse<int> resp = new ItemResponse<int>();
            int insertedId = ListingsService.Create(model);
            resp.Item = insertedId;

            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }

    }
}
