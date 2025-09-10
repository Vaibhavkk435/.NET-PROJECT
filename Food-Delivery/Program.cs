using FoodDeliveryApp.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();


// EF Core + SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


// Session for cart
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
options.Cookie.Name = ".FoodDelivery.Session";
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
app.UseExceptionHandler("/Home/Error");
app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();


app.UseAuthorization();
app.UseSession();


app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();