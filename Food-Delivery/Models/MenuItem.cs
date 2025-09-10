using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FoodDeliveryApp.Models
{
public class MenuItem
{
public int Id { get; set; }
[Required]
public int RestaurantId { get; set; }
public Restaurant? Restaurant { get; set; }


[Required, MaxLength(120)]
public string Name { get; set; } = string.Empty;


[MaxLength(500)]
public string? Description { get; set; }


[Range(0, 100000)]
[Column(TypeName = "decimal(10,2)")]
public decimal Price { get; set; }


public string? ImageUrl { get; set; }
}
}