using IEAPTLab2.Validation;
using System.ComponentModel.DataAnnotations;

namespace IEAPTLab2.Models
{
    public class Season
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Сезон обов'язково повинен мати назву")]
        [MinLength(3)]
        [MaxLength(50)]
        [Display(Name = "Назва сезону")]
        public string Name { get; set; }

        [StartDateLessThanEndDate]
        [Required(ErrorMessage = "Сезон обов'язково повинен мати дату початку")]
        [Display(Name = "Дата початку сезону")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }

        [StartDateLessThanEndDate]
        [Required(ErrorMessage = "Сезон обов'язково повинен мати дату кінця")]
        [Display(Name = "Дата кінця сезону")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }

        [MaxLength(225)]
        [Display(Name = "Опис сезону")]
        public string? Description { get; set; }
    }
}