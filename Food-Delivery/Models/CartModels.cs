using System.Collections.Generic;
using System.Linq;
using System.Text.Json;


namespace FoodDeliveryApp.Models
{
public class CartItemVM
{
public int MenuItemId { get; set; }
public string Name { get; set; } = string.Empty;
public decimal UnitPrice { get; set; }
public int Quantity { get; set; }
public decimal LineTotal => UnitPrice * Quantity;
}


public static class CartSession
{
private const string Key = "CART";
public static List<CartItemVM> GetCart(this Microsoft.AspNetCore.Http.ISession session)
{
var json = session.GetString(Key);
return json is null ? new List<CartItemVM>() : JsonSerializer.Deserialize<List<CartItemVM>>(json) ?? new();
}
public static void SaveCart(this Microsoft.AspNetCore.Http.ISession session, List<CartItemVM> items)
{
session.SetString(Key, JsonSerializer.Serialize(items));
}
}
}