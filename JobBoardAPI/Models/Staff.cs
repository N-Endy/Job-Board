namespace JobBoardAPI.Models;

public class Staff : User
{
    public int StaffId { get; set; }
    public ICollection<JobPost> JobPosts { get; set; }
}