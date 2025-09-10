using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.Models
{
    public class DataViewModel
    {
        public List<Restaurant> Restaurants { get; set; } = new();
        public List<MenuItem> MenuItems { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
