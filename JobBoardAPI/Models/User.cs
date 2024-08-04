using JobBoardAPI.Enums;

namespace JobBoardAPI.Models;
public class User
{
    public string UserName { get; set;} = string.Empty;
    public string Password { get; set;}
    public UserType UserType { get; set;}
}