using JobBoardInterface.Models;

namespace JobBoardInterface.Controllers;
public interface IStaffController
{
    void Add(Staff staff);
    Staff GetStaffLogin(string username);
    Staff GetStaff();
}
