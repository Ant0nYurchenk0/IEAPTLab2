using IEAPTLab2.Models;
using System.ComponentModel.DataAnnotations;

namespace IEAPTLab2.Validation
{
    public class EmailOrPhone : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var order = (Order)validationContext.ObjectInstance;

            if(order.Phone != null || order.Email != null)
                return ValidationResult.Success;
            return new ValidationResult("Обов'язково вкажіть хоча б один спосіб зв'язку");
        }
    }
}
