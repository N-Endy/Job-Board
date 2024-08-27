namespace JobBoardInterface.Models;
public class JobPost
{
    public int JobPostId { get; set;}
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int StaffId { get; set; }
    public Staff? Staff { get; set; }
    public ICollection<Application>? Applications { get; set; }}