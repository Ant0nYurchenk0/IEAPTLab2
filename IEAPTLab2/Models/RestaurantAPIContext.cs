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
        public RestaurantAPIContext(DbContextOptions<RestaurantAPIContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
