using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter your username")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string password { get; set; }
    }
}
