using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRegister.Models
{
    public class TeacherDTO
    {
        [Required]
        [StringLength(30, ErrorMessage = "Please enter surname between 2 and 30 characters"), MinLength(2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Please enter surname between 2 and 30 characters"), MinLength(2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Birthday")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Subject Subject { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Please enter a value in the range between 6 and 20 characters", MinimumLength = 4)]
        public string Password { get; set; }
    }
}
