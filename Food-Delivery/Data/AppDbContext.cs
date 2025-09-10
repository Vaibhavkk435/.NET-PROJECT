using FoodDeliveryApp.Models;
using Microsoft.EntityFrameworkCore;


namespace FoodDeliveryApp.Data
{
public class AppDbContext : DbContext
{
public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


public DbSet<Restaurant> Restaurants => Set<Restaurant>();
public DbSet<MenuItem> MenuItems => Set<MenuItem>();
public DbSet<Order> Orders => Set<Order>();
public DbSet<OrderItem> OrderItems => Set<OrderItem>();


protected override void OnModelCreating(ModelBuilder modelBuilder)
{
base.OnModelCreating(modelBuilder);
// Seed some sample data with local images
modelBuilder.Entity<Restaurant>().HasData(
new Restaurant { Id = 1, Name = "Spice Hub", Address = "MG Road", ImageUrl = "/images/spice lab.jpg" },
new Restaurant { Id = 2, Name = "Burger Bean", Address = "Park Street", ImageUrl = "/images/Burger bean.webp" },
new Restaurant { Id = 3, Name = "Pizza Palace", Address = "Central Mall", ImageUrl = "/images/Pizza palace.webp" },
new Restaurant { Id = 4, Name = "Curry Express", Address = "Food Street", ImageUrl = "/images/Curry palace.webp" }
);
modelBuilder.Entity<MenuItem>().HasData(
new MenuItem { Id = 1, RestaurantId = 1, Name = "Paneer Tikka", Price = 220, Description = "Delicious grilled paneer with spices", ImageUrl = "/images/Paneer Tikka.webp" },
new MenuItem { Id = 2, RestaurantId = 1, Name = "Veg Biryani", Price = 180, Description = "Aromatic basmati rice with mixed vegetables", ImageUrl = "/images/Veg Biryani.webp" },
new MenuItem { Id = 3, RestaurantId = 2, Name = "Classic Burger", Price = 150, Description = "Juicy beef patty with fresh vegetables", ImageUrl = "/images/Burger bean.webp" },
new MenuItem { Id = 4, RestaurantId = 3, Name = "Margherita Pizza", Price = 280, Description = "Fresh tomato sauce, mozzarella, and basil", ImageUrl = "/images/margherita pizza.jpg" },
new MenuItem { Id = 5, RestaurantId = 3, Name = "Pepperoni Pizza", Price = 320, Description = "Classic pepperoni with mozzarella cheese", ImageUrl = "/images/Pepproni pizza.jpg" },
new MenuItem { Id = 6, RestaurantId = 4, Name = "Chicken Curry", Price = 250, Description = "Tender chicken in rich spicy gravy", ImageUrl = "/images/Chicken Curry.jpg" },
new MenuItem { Id = 7, RestaurantId = 4, Name = "Dal Tadka", Price = 120, Description = "Yellow lentils with aromatic spices", ImageUrl = "/images/Dal.jpg" }
);
}
}
}