using TeamManageApp.Models;

namespace TeamManageApp.Repositories.IssueListRepository
{
    public interface IIssueListRepository
    {
        Task<int> CreateIssueList(int issueId);

        Task<List<int>> CreateIssueLists(List<int> issueIds);
    }
}
