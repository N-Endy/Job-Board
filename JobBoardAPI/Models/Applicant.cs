namespace JobBoardAPI.Models;
public class Applicant : User
{
    public int ApplicantId { get; set;}
    public ICollection<Application> Applications { get; set; }
}