using ASp_MVC.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace ASp_MVC.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле 'Логін' є обов'язковим.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина рядка має бути від 3 до 50 символів")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле 'Пароль' є обов'язковим.")]
        public string? Password { get; set; }


       

        
    }

 

}