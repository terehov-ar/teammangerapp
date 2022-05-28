using TeamManageApp.Models;

namespace TeamManageApp.Services.TeamService
{
    public interface ITeamService
    {
        Task<List<Team>> GetAllTeams(int skip, int take);

        Task<int> CreateTeam(Team team);

        Task DeleteTeam(int teamId);
    }
}
