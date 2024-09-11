namespace UI.Contracts.Views
{
    public interface IStaffView
    {
        Task LoginMenuAsync();
        Task RegisterStaffAsync();
        Task LoginStaffAsync();
    }
}