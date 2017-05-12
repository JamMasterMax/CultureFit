using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZipHackathon.Models.Request
{
    public class SubmissionCreateRequest
    {
        public int ListingId { get; set; }

        public int SeekerId { get; set; }

        public string ResumeUrl { get; set; }

        public string VideoUrl { get; set; }
        
    }
}