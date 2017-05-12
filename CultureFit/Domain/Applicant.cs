using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZipHackathon.Domain
{
    public class Applicant
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string VideoPrompt { get; set; }
        public string VideoUrl { get; set; }
        public int SubmissionId { get; set; }
    }
}