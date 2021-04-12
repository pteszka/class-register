using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassRegister.Models
{
    public class ClassDTO
    {
        [Required]
        [Range(1, 8, ErrorMessage = "Grade should be number between {1} and {2}")]
        public int Grade { get; set; }

        [Required]
        public char Letter { get; set; }
    }
}