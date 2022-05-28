using TeamManageApp.Models;
using TeamManageApp.Repositories.UserRepository;
using TeamManageApp.Services.HashPasswordService;

namespace TeamManageApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(
              IUserRepository userRepository
            )
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await _userRepository.GetUserByLogin(login);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<List<User>> GetUsers(int skip, int take)
        {
            return await _userRepository.GetAllUsers(skip, take);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateUser(user);
        }

        public async Task AddUserToTeam(int userId, int teamId)
        {
            await _userRepository.SetTeamId(userId, teamId);
        }

        public async Task<int> AddUser(User user)
        {
            return await _userRepository.CreateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }
    }
}
