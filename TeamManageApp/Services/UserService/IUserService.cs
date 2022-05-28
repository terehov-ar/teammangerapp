using TeamManageApp.Models;

namespace TeamManageApp.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetUserByLogin(string login);

        Task UpdateUser(User user);

        Task<User> GetUserById(int id);

        Task<List<User>> GetUsers(int skip, int take);

        Task<int> AddUser(User user);

        Task DeleteUser(int id);

        Task AddUserToTeam(int userId, int teamId);
    }
}
