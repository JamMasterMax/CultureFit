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
    [RoutePrefix("api/submissions")]
    public class SubmissionsApiController : ApiController
    {
        [Route(), HttpPost]
        public HttpResponseMessage CreateSubmission(SubmissionCreateRequest submission)
        {
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = SubmissionService.CreateSubmission(submission);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage SelectById(int id)
        {
            ItemResponse<Submission> response = new ItemResponse<Submission>();
            response.Item = SubmissionService.GetById(id);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("listing/{id:int}"), HttpGet]
        public HttpResponseMessage SelectBySubmissionID(int id)
        {
            List<Submission> submissions = SubmissionService.GetByListingId(id);
            ItemsResponse<Submission> response = new ItemsResponse<Submission>();
            response.Items = submissions;

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("applicants/{id:int}"), HttpGet]
        public HttpResponseMessage GetAllSubmissionsByListingId(int id)
        {
            ItemsResponse<ListingApplicant> response = new ItemsResponse<ListingApplicant>();
            response.Items = ListingsService.GetAllSeekersByListingId(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [Route("applicant/{id:int}"), HttpGet]
        public HttpResponseMessage GetApplicantById(int id)
        {
            ItemResponse<Applicant> response = new ItemResponse<Applicant>
            {
                Item = SubmissionService.GetApplicantById(id)
            };
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}
