using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRegister.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public Subject subject { get; set; }

        [Required]
        public PersonalInfo PersonalInfo { get; set; }
        public Account Account { get; set; }
    }
}
