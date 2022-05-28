using TeamManageApp.Models;
using TeamManageApp.Repositories.TeamRepository;

namespace TeamManageApp.Services.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<List<Team>> GetAllTeams(int skip, int take)
        {
            return await _teamRepository.GetAllTeams(skip, take);
        }

        public async Task<int> CreateTeam(Team team)
        {
            return await _teamRepository.CreateTeam(team);
        }

        public async Task DeleteTeam(int teamId)
        {
            await _teamRepository.DeleteTeam(teamId);
        }
    }
}
