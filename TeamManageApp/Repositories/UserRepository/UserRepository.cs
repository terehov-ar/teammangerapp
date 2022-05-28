using Microsoft.EntityFrameworkCore;
using TeamManageApp.Data;
using TeamManageApp.Models;

namespace TeamManageApp.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> CreateUser(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<List<User>> GetAllUsers(int skip = 0, int take = 30)
        {
            return await _context.User.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<User> GetUserByLogin(string login)
        {
            var user = await _context.User.Include(u => u.AsigneeIssues)
                    .ThenInclude(i => i.Team)
                .Include(u => u.ReporterIssues)
                    .ThenInclude(i => i.Team)
                .FirstOrDefaultAsync(x => x.Login == login);

            if (user is null)
            {
                throw new Exception("User isn't exist");
            }

            return user;
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == userId);

            if (user is null)
            {
                throw new Exception("User isn't exist");
            }

            return user;
        }

        public async Task SetTeamId(int userId, int teamId)
        {
            var user = await GetUserById(userId);

            if (user is null)
            {
                throw new Exception("User isn't exist");
            }

            user.TeamId = teamId;

            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            _context.User.Remove(await GetUserById(id));
            await _context.SaveChangesAsync();
        }
    }
}
