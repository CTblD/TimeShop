using System.ComponentModel.DataAnnotations;

namespace TIMEShop1.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Электронная почта")]
        [Required(ErrorMessage ="Обязательна электронная почта")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)] 
        public string Password { get; set; }
        [Display(Name = "Подтверждение пароля")]
        [Required(ErrorMessage = " Подтвердите пароль")]
        [Compare("Password", ErrorMessage ="Пароль не совпадает")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
