using Microsoft.EntityFrameworkCore;

namespace IEAPTLab2.Models
{
    public class RestaurantAPIContext : DbContext
    {
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<DishIngredient> DishIngredients { get; set; }
        public virtual DbSet<MenuDish> MenuDishes { get; set; }
        public virtual DbSet<OrderedDish> OrderedDishes { get; set; }

        public RestaurantAPIContext(DbContextOptions<RestaurantAPIContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
