using Microsoft.EntityFrameworkCore;
using TeamManageApp.Data;
using TeamManageApp.Models;

namespace TeamManageApp.Repositories.TeamRepository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly Context _context;

        public TeamRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> CreateTeam(Team team)
        {
            await _context.Team.AddAsync(team);
            await _context.SaveChangesAsync();

            return team.Id;
        }

        public async Task<Team> GetTeam(int id)
        {
            return await _context.Team.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task DeleteTeam(int teamId)
        {
            _context.Team.Remove(await GetTeam(teamId));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Team>> GetAllTeams(int skip, int take)
        {
            return await _context.Team.Include(t => t.Users).Skip(skip).Take(take).ToListAsync();
        }

        public async Task UpdateTeam(Team team)
        {
            _context.Team.Update(team);
            await _context.SaveChangesAsync();
        }
    }
}
