using JobBoardAPI.Enums;

namespace JobBoardAPI.Models;
public class User
{
    public string UserName { get; set;}
    public string Password { get; set;}
    public UserType UserType { get; set;}
}