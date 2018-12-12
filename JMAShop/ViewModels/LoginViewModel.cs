using System.ComponentModel.DataAnnotations;

namespace JMAShop.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        ////[Required]
        ////[Display(Name = "Email")]
        ////[DataType (DataType.EmailAddress)]
        //public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }

}
