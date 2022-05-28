using TeamManageApp.Models;

namespace TeamManageApp.ViewModels
{
    public class IssueModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Comments { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; } = "OPEN";

        public int AssigneeId { get; set; }

        public int ReporterId { get; set; }

        public IEnumerable<UserEditModel> Reporters { get; set; }

        public IEnumerable<UserEditModel> Asignees { get; set; }

        public IEnumerable<Issue> IssuesAsignee { get; set; }

        public User You { get; set; }

        public Issue Issue { get; set; }

        public IEnumerable<Issue> LinkedIssues { get; set; }
        public IEnumerable<int> LinkedIssuesIds { get; set; }
    }
}
