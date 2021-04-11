using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClassRegister.Models 
{
    // attribute make sure that email is unique
    [Index(nameof(Account.Email), IsUnique = true)]
    public class Account
    {   
        [Key]
        // [ScaffoldColumn(false)]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
