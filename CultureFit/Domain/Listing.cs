using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZipHackathon.Domain
{
    public class Listing
    {
        public int ListingID { get; set; }

        public int ManagerID { get; set; }

        public int DepartmentID { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Role { get; set; }

        public string Description { get; set; }

        public bool VideoIsEnabled { get; set; }

        public string VideoPrompt { get; set; }
    }
}