using System.ComponentModel.DataAnnotations;

namespace TeamManageApp.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Set login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Set password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
