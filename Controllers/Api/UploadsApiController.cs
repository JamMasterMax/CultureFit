using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ZipHackathon.Domain;
using ZipHackathon.Models.Request;
using ZipHackathon.Models.Response;
using ZipHackathon.Services;

namespace ZipHackathon.Controllers.Api
{
    [RoutePrefix("api/upload")]
    public class UploadsApiController : ApiController
    {
        [Route(), HttpPost]
        public HttpResponseMessage Upload()
        {
            //this request variable will house information pertaining to the upload request
            HttpRequest request = HttpContext.Current.Request;
            ItemsResponse<string> resp = new ItemsResponse<string>();
            resp.Items = new List<string>();
            string path;

            AwsStorageService awsStorage = new AwsStorageService();

            //check if request content type is "multipart/form-data" (which implies it came as a file upload)
            if (Request.Content.IsMimeMultipartContent())
            {
                foreach (string file in request.Files)
                {
                    HttpPostedFile hpf = request.Files[file];
                    path = awsStorage.Upload(hpf.FileName, hpf.InputStream, hpf.ContentLength);

                    resp.Items.Add(path);
                }
            }

            //if not "multipart/form-data", for now let's assume it is a direct GIF url
            else
            {
                //place the value from the request into an array, and set our model url to the first array value
                string[] requestContent = Request.Content.ReadAsFormDataAsync().Result.GetValues("url");

                UploadsCreateRequest model = new UploadsCreateRequest();
                model.Url = requestContent[0];

                //create a stream to store the GIF
                Stream fileStream = null;

                using (WebResponse response = WebRequest.Create(string.Format(model.Url)).GetResponse())
                {
                    //assign the GIF to the stream
                    fileStream = response.GetResponseStream();
                    path = awsStorage.Upload(model.Url, fileStream, response.ContentLength);

                    resp.Items.Add(path);

                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
    }
}
