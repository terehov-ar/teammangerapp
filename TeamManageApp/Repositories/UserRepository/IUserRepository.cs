using TeamManageApp.Models;

namespace TeamManageApp.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<int> CreateUser(User user);

        Task<List<User>> GetAllUsers(int skip, int take);

        Task<User> GetUserByLogin(string login);

        Task SetTeamId(int userId, int teamId);

        Task UpdateUser(User user);

        Task<User> GetUserById(int userId);

        Task DeleteUser(int id);
    }
}
