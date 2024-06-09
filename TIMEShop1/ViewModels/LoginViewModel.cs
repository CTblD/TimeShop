using System.ComponentModel.DataAnnotations;

namespace TIMEShop1.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Электронная почта")]
        [Required(ErrorMessage ="Нужно ввести электронную почту")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
