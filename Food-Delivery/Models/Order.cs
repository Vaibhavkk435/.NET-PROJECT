using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FoodDeliveryApp.Models
{
public class Order
{
public int Id { get; set; }
public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
[MaxLength(120)] public string CustomerName { get; set; } = string.Empty;
[MaxLength(200)] public string DeliveryAddress { get; set; } = string.Empty;
[MaxLength(20)] public string Phone { get; set; } = string.Empty;
[Column(TypeName = "decimal(10,2)")] public decimal Total { get; set; }
public string Status { get; set; } = "Pending"; // Pending, Preparing, OutForDelivery, Delivered
public List<OrderItem> Items { get; set; } = new();
}


public class OrderItem
{
public int Id { get; set; }
public int OrderId { get; set; }
public Order? Order { get; set; }


public int MenuItemId { get; set; }
public MenuItem? MenuItem { get; set; }


public int Quantity { get; set; }
[Column(TypeName = "decimal(10,2)")] public decimal UnitPrice { get; set; }
[Column(TypeName = "decimal(10,2)")] public decimal LineTotal { get; set; }
}
}