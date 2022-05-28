using System.ComponentModel.DataAnnotations;

namespace TeamManageApp.ViewModels
{
    public class UserEditModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Set full name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Set full name")]
        public string Login { get; set; }
    }
}
