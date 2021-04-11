using System.ComponentModel.DataAnnotations;

namespace ClassRegister.Models 
{
    public enum Subject 
    {
        [Display(Name = "Not Selected")]
        English,
        Biology,
        Chemistry,
        Math
    }
}