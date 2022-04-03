using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Validations
{
    public class CheckDate : ValidationAttribute
    {
        public CheckDate()
        {
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var date = Convert.ToDateTime(value);
            if (date < DateTime.Now)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"لا يمكن وضع تاريخ سابق";
        }

    }
}
