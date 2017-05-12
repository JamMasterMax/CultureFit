using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZipHackathon.Domain
{
    public class Submission
    {
        public int SubmissionId { get; set; }
        public int ListingId { get; set; }
        public int SeekerId { get; set; }
        public string ResumeUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}