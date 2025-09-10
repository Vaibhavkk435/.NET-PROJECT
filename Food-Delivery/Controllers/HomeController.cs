using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Food_Delivery.Models;
using FoodDeliveryApp.Data;
using FoodDeliveryApp.Models;

namespace Food_Delivery.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetPopularRestaurants()
    {
        try
        {
            var restaurants = await _context.Restaurants
                .Select(r => new
                {
                    r.Id,
                    r.Name,
                    r.Address,
                    r.ImageUrl
                })
                .ToListAsync();

            return Json(restaurants);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching popular restaurants");
            return Json(new List<object>());
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetFeaturedItems()
    {
        try
        {
            var menuItems = await _context.MenuItems
                .Include(m => m.Restaurant)
                .Select(m => new
                {
                    m.Id,
                    m.Name,
                    m.Price,
                    m.ImageUrl,
                    RestaurantName = m.Restaurant != null ? m.Restaurant.Name : "Unknown"
                })
                .ToListAsync();

            return Json(menuItems);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching featured items");
            return Json(new List<object>());
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
