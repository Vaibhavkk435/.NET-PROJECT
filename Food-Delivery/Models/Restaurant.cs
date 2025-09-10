using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Address { get; set; }

        public string? ImageUrl { get; set; }

        public List<MenuItem> MenuItems { get; set; } = new();
    }
}
