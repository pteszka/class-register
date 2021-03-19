using System.ComponentModel.DataAnnotations;

namespace ClassRegister.ViewModels
{
    public class LoginViewModel 
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Please enter a value in the range between 6 and 20 characters", MinimumLength = 4)]
        public string Password { get; set; }
    }
}
