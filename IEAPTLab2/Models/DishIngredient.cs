using System.ComponentModel.DataAnnotations;

namespace IEAPTLab2.Models
{
    public class DishIngredient
    {
        public int Id { get; set; }
        [Required]
        public int DishId { get; set; }
        [Required]
        public int IngredientId { get; set; }
        public Dish Dish { get; set; }
        public Ingredient Ingredient { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
