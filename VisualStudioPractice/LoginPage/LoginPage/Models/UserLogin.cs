using System.ComponentModel.DataAnnotations;

namespace LoginPage.Models
{
    public class UserLogin
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please Enter UserName")]
        [Display(Name = "Please Enter UserName")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Passcode")]
        [Display(Name = "Please Enter Passcode")]
        public string? passCode { get; set; }


        public int isActive { get; set; }
    }
}
