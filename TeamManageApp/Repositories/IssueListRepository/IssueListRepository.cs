using TeamManageApp.Data;
using TeamManageApp.Models;

namespace TeamManageApp.Repositories.IssueListRepository
{
    public class IssueListRepository : IIssueListRepository
    {
        private readonly Context _context;

        public IssueListRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> CreateIssueList(int issueId)
        {
            var issueList = new IssueList { MainIssueId = issueId };
            await _context.IssueList.AddAsync(issueList);
            await _context.SaveChangesAsync();

            return issueList.Id;
        }

        public async Task<List<int>> CreateIssueLists(List<int> issueIds)
        {
            var issueList = issueIds.Select(i => new IssueList { MainIssueId = i });
            await _context.IssueList.AddRangeAsync(issueList);
            await _context.SaveChangesAsync();

            return issueList.Select(i => i.Id).ToList();
        }
    }
}
