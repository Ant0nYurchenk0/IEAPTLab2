using System.ComponentModel.DataAnnotations;

namespace IEAPTLab2.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Інгредієнт обов'язково повинен мати назву")]
        [MinLength(3)]
        [MaxLength(50)]
        [Display(Name = "Назва інгредієнту")]
        public string Name { get; set; }

        [MaxLength(225)]
        [Display(Name = "Опис інгредієнту")]
        public string? Description { get; set; }
    }
}
