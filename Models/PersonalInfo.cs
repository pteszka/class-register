using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRegister.Models
{
    public class PersonalInfo
    {
        [Key]
        public int PersonalInfoId { get; set; }

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
    }
}
