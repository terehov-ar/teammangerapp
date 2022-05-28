using TeamManageApp.Models;

namespace TeamManageApp.Services.HashPasswordService
{
    public interface IHashPasswordService
    {
        string HashPassword(string password);

        Task<User> Logging(string login, string password);
    }
}
