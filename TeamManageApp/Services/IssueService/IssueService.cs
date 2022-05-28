using TeamManageApp.Models;
using TeamManageApp.Repositories.IssueListRepository;
using TeamManageApp.Repositories.IssueRepository;

namespace TeamManageApp.Services.IssueService
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IIssueListRepository _issueListRepository;

        public IssueService(
            IIssueRepository issueRepository
            , IIssueListRepository issueListRepository)
        {
            _issueRepository = issueRepository;
            _issueListRepository = issueListRepository;
        }

        public async Task<int> CreateIssue(Issue issue, List<int>? LinkedIssuesIds)
        {
            var issueId = await _issueRepository.CreateIssue(issue);

            if (LinkedIssuesIds is not null && LinkedIssuesIds.Count != 0)
            {
                var issueListId = await _issueListRepository.CreateIssueList(issueId);

                foreach (var item in LinkedIssuesIds)
                {
                    await SetIssueListToIssue(item, issueListId);
                }
            }

            return issueId;
        }

        public async Task<List<Issue>> GetAllIssues(int skip, int take)
        {
            return await _issueRepository.GetAllIssues(skip, take);
        }

        public async Task<Issue> GetIssue(int id)
        {
            return await _issueRepository.GetIssue(id);
        }

        public async Task SetIssueListToIssue(int issueId, int? listId)
        {

            await _issueRepository.SetIssueListToIssue(issueId, listId);
        }

        public async Task UpdateIssue(Issue issue, List<int> LinkedIssuesIds)
        {
            try
            {
                var issueForUpdate = await GetIssue(issue.Id);
                issueForUpdate.Description = issue.Description;
                issueForUpdate.AsigneeId = issue.AsigneeId;
                issueForUpdate.Name = issue.Name;
                issueForUpdate.Priority = issue.Priority;
                issueForUpdate.ReporterId = issue.ReporterId;
                issueForUpdate.Status = issue.Status;
                issueForUpdate.Comments = issue.Comments;

                //LinkedIssuesIds.Add(issue.Id);

                if (LinkedIssuesIds is null)
                {
                    var existedLinkedIssuesIds = issueForUpdate?.IssueList?.Issues?.Select(x => x.Id)?.ToList();

                    if (existedLinkedIssuesIds is not null)
                    {
                        foreach (var item in existedLinkedIssuesIds)
                        {
                            await SetIssueListToIssue(item, null);
                        }
                    }
                }

                int? issueListId = default;
                if (LinkedIssuesIds is not null)
                {
                    if (issueForUpdate.LinkIssues is null)
                    {
                        issueListId = await _issueListRepository.CreateIssueList(issue.Id);
                    }
                    else
                    {
                        issueListId = issueForUpdate.LinkIssues.Id;

                        var existedLinkedIssuesIds = issueForUpdate.LinkIssues.Issues.Select(x => x.Id).ToList();

                        List<int>? issuesForUnsetIssueList;
                        if (LinkedIssuesIds is null)
                        {
                            issuesForUnsetIssueList = existedLinkedIssuesIds;
                        }
                        else
                        {
                            issuesForUnsetIssueList = existedLinkedIssuesIds.Except(LinkedIssuesIds).ToList();
                        }


                        foreach (var item in issuesForUnsetIssueList)
                        {
                            await SetIssueListToIssue(item, null);
                        }
                    }
                }

                await _issueRepository.UpdateIssue(issueForUpdate);

                if (LinkedIssuesIds is not null)
                {
                    foreach (var item in LinkedIssuesIds)
                    {
                        await SetIssueListToIssue(item, issueListId);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteIssue(int id)
        {
            await _issueRepository.DeleteIssue(id);
        }
    }
}
