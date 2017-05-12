using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZipHackathon.Domain;
using ZipHackathon.Models.Response;
using ZipHackathon.Services;

namespace ZipHackathon.Controllers.Api
{
    [RoutePrefix("api/test")]
    public class TestApiController : ApiController
    {
        [Route(), HttpGet]
        public HttpResponseMessage SelectAll()
        {
            ItemsResponse<TestPerson> response = new ItemsResponse<TestPerson>();
            response.Items = TestService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route(), HttpPost]
        public HttpResponseMessage InsertPerson()
        {
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = TestService.TestInsert();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}