namespace JobBoardInterface.Models;
public class Applicant
{
    public int ApplicantId { get; set;}
    public ICollection<Application> Applications { get; set; }
}