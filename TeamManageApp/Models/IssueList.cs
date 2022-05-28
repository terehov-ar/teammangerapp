using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManageApp.Models
{
    public class IssueList
    {
        [Key]
        public int Id { get; set; }
        
        [InverseProperty("LinkIssues")]
        public List<Issue> Issues { get; set; }


        public int MainIssueId { get; set; }

        [InverseProperty("IssueList")]
        [ForeignKey("MainIssueId")]
        public Issue MainIssue { get; set; }
    }
}
