using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoardAPI.Models;
public class JobPost
{
    public int JobPostId { get; set;}
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int StaffId { get; set; }
    [ForeignKey(nameof(StaffId))]
    public Staff? Staff { get; set; }
    public ICollection<Application>? Applications { get; set; }}