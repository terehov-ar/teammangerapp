using TeamManageApp.Models;

namespace TeamManageApp.Services.IssueService
{
    public interface IIssueService
    {

        Task<List<Issue>> GetAllIssues(int skip, int take);

        Task<Issue> GetIssue(int id);

        Task SetIssueListToIssue(int issueId, int? listId);

        Task DeleteIssue(int id);

        Task<int> CreateIssue(Issue issue, List<int>? LinkedIssuesIds);

        Task UpdateIssue(Issue issue, List<int> LinkedIssuesIds);
    }
}
