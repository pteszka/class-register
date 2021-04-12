using System;
using System.ComponentModel.DataAnnotations;

namespace ClassRegister.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public PersonalInfo PersonalInfo { get; set; }

        [Required]
        public Account Account { get; set; }
        
        [Required]
        public Class Class {get; set;}
    }
}