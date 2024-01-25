using System;
using System.ComponentModel.DataAnnotations;
namespace ASp_MVC.Models.Validators
{
    public class WeekMondayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;

            var model = (Consult)validationContext.ObjectInstance;

            if (model.Subject == "Основи" && date.DayOfWeek == DayOfWeek.Monday)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

}

