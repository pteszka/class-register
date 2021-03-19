using System.ComponentModel.DataAnnotations;

namespace ClassRegister.Models 
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Please enter a value in the range between 6 and 20 characters", MinimumLength = 4)]
        public string Password { get; set; }
        
        public Roles Role { get; set; }
    }  
}
