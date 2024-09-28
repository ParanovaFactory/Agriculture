using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username can not be empty")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Email can not be empty")]
        public string mail { get; set; }

        [Required(ErrorMessage = "password can not be empty")]
        public string password { get; set; }

        [Required(ErrorMessage = "Confirm password can not be empty")]
        [Compare("password", ErrorMessage = "Both passwords have to be same")]
        public string passwordConfirm { get; set; }
    }
}
