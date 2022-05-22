using System.ComponentModel.DataAnnotations;

namespace IEAPTLab2.Models
{
    public class Dish
    {
        public Dish()
        {
            Ingredients = new List<Ingredient>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage ="Страва обов'язково повинен мати назву")]
        [MinLength(3)]
        [MaxLength(50)]
        [Display(Name ="Назва страви")]
        public string Name { get; set; }

        [MaxLength(225)]
        [Display(Name = "Опис страви")]
        public string? Description { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
