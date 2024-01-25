using System.ComponentModel.DataAnnotations;

namespace ASp_MVC.Models.Validators
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Now;
            }
            return false;
        }
    }

}
