using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManageApp.Models
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public int? ListId { get; set; }

        [InverseProperty("Issues")]
        [ForeignKey("ListId")]
        public IssueList? LinkIssues { get; set; }


        [InverseProperty("MainIssue")]
        public IssueList? IssueList { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }



        public int ReporterId { get; set; }

        [InverseProperty("ReporterIssues")]
        [ForeignKey("ReporterId")]
        public User Reporter { get; set; }

        public int AsigneeId { get; set; }

        [InverseProperty("AsigneeIssues")]
        [ForeignKey("AsigneeId")]
        public User Asignee { get; set; }
    }
}
