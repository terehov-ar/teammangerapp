using Microsoft.EntityFrameworkCore;
using TeamManageApp.Data;
using TeamManageApp.Models;

namespace TeamManageApp.Repositories.IssueRepository
{
    public class IssueRepository : IIssueRepository
    {
        private readonly Context _context;

        public IssueRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> CreateIssue(Issue issue)
        {
            await _context.Issue.AddAsync(issue);
            await _context.SaveChangesAsync();

            return issue.Id;
        }

        public async Task<List<Issue>> GetAllIssues(int skip, int take)
        {
            return await _context.Issue.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Issue> GetIssue(int id)
        {
            return await _context.Issue.Include(i => i.Asignee)
                .Include(i => i.Reporter)
                //.Include(i => i.)
                .Include(i => i.IssueList).ThenInclude(i => i.Issues)
                .Include(i => i.Team)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task SetIssueListToIssue(int issueId, int? listId)
        {
            var issue = await GetIssue(issueId);
            if (issue is null)
            {
                throw new Exception("Issue isn't exists");
            }

            issue.ListId = listId;

            _context.Issue.Update(issue);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIssue(Issue issue)
        {
            _context.Issue.Update(issue);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIssue(int id)
        {
            _context.Issue.Remove(await GetIssue(id));
            await _context.SaveChangesAsync();
        }
    }
}
