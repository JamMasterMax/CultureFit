using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZipHackathon.Domain
{
    public class TestPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}