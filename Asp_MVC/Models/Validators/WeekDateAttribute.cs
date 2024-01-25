using System;
using System.ComponentModel.DataAnnotations;
namespace ASp_MVC.Models.Validators
{
    public class WeekdayDateAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }
        
    }
}
