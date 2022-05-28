using TeamManageApp.Models;

namespace TeamManageApp.Repositories.IssueRepository
{
    public interface IIssueRepository
    {
        Task<int> CreateIssue(Issue issue);

        Task UpdateIssue(Issue issue);

        Task<List<Issue>> GetAllIssues(int skip, int take);

        Task<Issue> GetIssue(int id);

        Task SetIssueListToIssue(int issueId, int? listId);

        Task DeleteIssue(int id);
    }
}
