using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZipHackathon.Domain
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int SubmissionID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string EmployeeName { get; set; }
    }
}