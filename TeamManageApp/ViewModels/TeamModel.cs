using TeamManageApp.Models;

namespace TeamManageApp.ViewModels
{
    public class TeamModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Comments { get; set; }

        public string Methodologies { get; set; }

        public DateTime EstimateFrom { get; set; }

        public DateTime EstimateTo { get; set; }

        public List<int> UsersIds { get; set; }

        public IEnumerable<UserEditModel> Users { get; set; }

        public IEnumerable<Team> Teams { get; set; }
    }
}
