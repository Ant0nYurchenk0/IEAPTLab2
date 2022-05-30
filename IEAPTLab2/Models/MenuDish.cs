using System.ComponentModel.DataAnnotations;

namespace IEAPTLab2.Models
{
    public class MenuDish
    {
        public int Id { get; set; }

        [Required]
        public int DishId { get; set; }
        [Required]
        public int MenuId { get; set; }
        public Dish Dish { get; set; }
        public Ingredient Menu { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
