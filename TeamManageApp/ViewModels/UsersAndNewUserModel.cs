using TeamManageApp.Models;

namespace TeamManageApp.ViewModels
{
    public class UsersAndNewUserModel
    {
        public List<User> User { get; set; }

        public User NewUser{ get; set; }

        public List<string> Roles { get; set; }
    }
}
