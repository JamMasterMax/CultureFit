using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZipHackathon.Models.Request
{
    public class ReviewCreateRequest
    {
        public int SubmissionId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int DepartmentId { get; set; }
        public string Employee { get; set; }
    }
}