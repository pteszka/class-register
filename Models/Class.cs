using System;
using System.ComponentModel.DataAnnotations;

namespace ClassRegister.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        public int Grade { get; set; }

        [Required]
        public char Letter { get; set; }
    }
}