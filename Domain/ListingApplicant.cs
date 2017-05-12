using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZipHackathon.Domain
{
    public class ListingApplicant
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Rating { get; set; }
        public string VideoUrl { get; set; }
        public string ResumeUrl { get; set; }
        public int SubmissionId { get; set; }

    }
}