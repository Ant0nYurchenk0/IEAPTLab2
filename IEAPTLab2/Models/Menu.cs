using System.ComponentModel.DataAnnotations;

namespace IEAPTLab2.Models
{
    public class Menu
    {
        public Menu()
        {
            Dishes = new List<Dish>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Меню обов'язково повинен мати назву")]
        [MinLength(3)]
        [MaxLength(50)]
        [Display(Name = "Назва меню")]
        public string Name { get; set; }

        [MaxLength(225)]
        [Display(Name = "Опис меню")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Вкажіть до якого сезону належить меню")]
        [Display(Name = "Сезон")]
        public int SeasonId { get; set; }
        public Season Season { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}
