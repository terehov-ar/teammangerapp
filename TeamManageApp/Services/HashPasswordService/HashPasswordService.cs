using TeamManageApp.Models;
using TeamManageApp.Repositories.UserRepository;

namespace TeamManageApp.Services.HashPasswordService
{
    public class HashPasswordService : IHashPasswordService
    {
        private readonly IUserRepository _userRepository;

        public HashPasswordService(
              IUserRepository userRepository
            )
        {
            _userRepository = userRepository;
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 13);
        }

        public async Task<User> Logging(string login, string password)
        {
            var user = await _userRepository.GetUserByLogin(login);

            if (user == null)
            {
                throw new Exception("User isn't exist");
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (isValidPassword && user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("Password is invalid.");
            }
        }
    }
}
