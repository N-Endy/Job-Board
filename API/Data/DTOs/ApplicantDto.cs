using API.Data.Enums;

namespace API.Data.DTOs
{
    public class ApplicantDto
    {
        public int ApplicantId { get; set; }
        public string FullName { get; set; } = "";
        public UserType UserType { get; set; }
        public ICollection<ApplicationDto> Applications { get; set; } = [];
    }
}