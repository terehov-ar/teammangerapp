using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManageApp.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Comments { get; set; }

        public string Methodologies { get; set; }

        public DateTime EstimateFrom { get; set; }

        public DateTime EstimateTo { get; set; }


        public int CreaterId { get; set; }

        [ForeignKey("CreaterId")]
        [InverseProperty("CreatedTeams")]
        public User Creater { get; set; }


        [InverseProperty("Team")]
        public List<User>? Users { get; set; }


        public List<Issue>? Issues { get; set; }
    }
}
