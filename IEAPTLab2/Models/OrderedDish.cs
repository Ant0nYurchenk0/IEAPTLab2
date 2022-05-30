using System.ComponentModel.DataAnnotations;

namespace IEAPTLab2.Models
{
    public class OrderedDish
    {
        public int Id { get; set; }

        [Required]
        public int DishId { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public Ingredient Ingredient { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
