using FoodDeliveryApp.Data;
using FoodDeliveryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Controllers
{
    public class DataController : Controller
    {
        private readonly AppDbContext _context;

        public DataController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new DataViewModel
            {
                Restaurants = await _context.Restaurants.ToListAsync(),
                MenuItems = await _context.MenuItems.Include(m => m.Restaurant).ToListAsync(),
                Orders = await _context.Orders.ToListAsync(),
                OrderItems = await _context.OrderItems.Include(oi => oi.MenuItem).ToListAsync()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Restaurants()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            return Json(restaurants);
        }

        public async Task<IActionResult> MenuItems()
        {
            var menuItems = await _context.MenuItems.Include(m => m.Restaurant).ToListAsync();
            return Json(menuItems.Select(m => new {
                m.Id,
                m.Name,
                m.Description,
                m.Price,
                m.ImageUrl,
                RestaurantName = m.Restaurant?.Name,
                RestaurantId = m.RestaurantId
            }));
        }

        public async Task<IActionResult> Orders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Json(orders);
        }

        public async Task<IActionResult> OrderItems()
        {
            var orderItems = await _context.OrderItems.Include(oi => oi.MenuItem).ToListAsync();
            return Json(orderItems.Select(oi => new {
                oi.Id,
                oi.OrderId,
                MenuItemName = oi.MenuItem?.Name,
                oi.Quantity,
                UnitPrice = oi.UnitPrice,
                LineTotal = oi.LineTotal
            }));
        }

        public async Task<IActionResult> DatabaseStats()
        {
            var stats = new
            {
                RestaurantCount = await _context.Restaurants.CountAsync(),
                MenuItemCount = await _context.MenuItems.CountAsync(),
                OrderCount = await _context.Orders.CountAsync(),
                OrderItemCount = await _context.OrderItems.CountAsync(),
                TotalRevenue = await _context.OrderItems.SumAsync(oi => oi.LineTotal)
            };

            return Json(stats);
        }
    }
}
