namespace ZipHackathon.Models.Request
{
    public class ListingCreateRequest
    {
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