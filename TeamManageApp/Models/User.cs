using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManageApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Role { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        [InverseProperty("Creater")]
        public List<Team> CreatedTeams { get; set; }


        public int? TeamId { get; set; }

        [InverseProperty("Users")]
        [ForeignKey("TeamId")]
        public Team? Team { get; set; }

        [InverseProperty("Reporter")]
        public List<Issue> ReporterIssues { get; set; }

        [InverseProperty("Asignee")]
        public List<Issue> AsigneeIssues { get; set; }
    }
}
