using ASp_MVC.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace ASp_MVC.Models
{
    public class Consult
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле 'Ім'я прізвище' є обов'язковим.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле 'Email' є обов'язковим.")]
        [EmailAddress(ErrorMessage = "Невірний формат Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Виберіть продукт.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Поле 'Бажана дата консультації' є обов'язковим.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessage = "Дата має бути в майбутньому.")]
        [WeekdayDate(ErrorMessage = "Консультація не може проходити в вихідні.")]
        [WeekMonday(ErrorMessage = "Консультація щодо продукту 'Основи' не може проходити в понеділок.")]

        public DateTime Date { get; set; }

        
    }

 

}