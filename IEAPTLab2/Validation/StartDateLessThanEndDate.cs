using IEAPTLab2.Models;
using System.ComponentModel.DataAnnotations;

namespace IEAPTLab2.Validation
{
    public class StartDateLessThanEndDate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var season = (Season)validationContext.ObjectInstance;

            if (DateTime.Compare(season.StartDate, season.EndDate) > 0)
                return new ValidationResult("Дата початку має бути раніше дати кінця");
            return ValidationResult.Success;

        }
    }
}
