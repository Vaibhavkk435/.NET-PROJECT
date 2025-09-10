using Microsoft.AspNetCore.Mvc;
using FoodDeliveryApp.Models;

namespace FoodDeliveryApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddItem([FromBody] CartItem item)
        {
            // In a real application, you would handle cart logic here
            // For now, we'll just return success
            return Json(new { success = true, message = "Item added to cart" });
        }
        
        [HttpPost]
        public IActionResult RemoveItem([FromBody] int itemId)
        {
            // In a real application, you would remove the item from cart
            return Json(new { success = true, message = "Item removed from cart" });
        }
        
        [HttpPost]
        public IActionResult UpdateQuantity([FromBody] CartUpdateRequest request)
        {
            // In a real application, you would update the quantity
            return Json(new { success = true, message = "Quantity updated" });
        }
        
        [HttpPost]
        public IActionResult Checkout([FromBody] CheckoutRequest request)
        {
            // In a real application, you would process the order
            // For demo purposes, we'll simulate order creation
            
            var order = new Order
            {
                CustomerName = request.CustomerName,
                Phone = request.Phone,
                DeliveryAddress = request.DeliveryAddress,
                Total = request.Total,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };
            
            // Save order logic would go here
            
            return Json(new { 
                success = true, 
                message = "Order placed successfully!", 
                orderId = new Random().Next(1000, 9999) 
            });
        }
    }
    
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? ImageUrl { get; set; }
    }
    
    public class CartUpdateRequest
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
    
    public class CheckoutRequest
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
