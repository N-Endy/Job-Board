namespace UI.Data.Models
{
    public class JobPost
    {
        public int JobPostId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int StaffId { get; set; }
        public string StaffFullName { get; set; } = "";
        public List<Application> Applications { get; set; } = [];
    }
}