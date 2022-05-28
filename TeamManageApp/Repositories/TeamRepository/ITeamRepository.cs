using TeamManageApp.Models;

namespace TeamManageApp.Repositories.TeamRepository
{
    public interface ITeamRepository
    {
        Task<int> CreateTeam(Team team);

        Task UpdateTeam(Team team);

        Task<List<Team>> GetAllTeams(int skip, int take);

        Task DeleteTeam(int teamId);

        Task<Team> GetTeam(int id);
    }
}
