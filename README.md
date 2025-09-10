# 🍕 Food Delivery Web Application

A modern, responsive Food Delivery application built with **ASP.NET Core 8.0** and **Entity Framework Core** with **SQLite** database.

![Food Delivery App](https://img.shields.io/badge/ASP.NET%20Core-8.0-blue) ![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-green) ![SQLite](https://img.shields.io/badge/Database-SQLite-orange)

## 🚀 Features

- **🏪 Restaurant Management** - Browse 4 different restaurants
- **🍽️ Menu Items** - View detailed menu with prices and descriptions
- **🖼️ Local Images** - High-quality food images stored locally
- **📊 Data Viewer** - Comprehensive database browser
- **🛒 Shopping Cart** - Add items to cart functionality
- **📱 Responsive Design** - Works on desktop and mobile
- **🎨 Modern UI** - Bootstrap-based attractive interface

## 🏗️ Tech Stack

- **Backend:** ASP.NET Core 8.0 MVC
- **Database:** SQLite with Entity Framework Core
- **Frontend:** HTML5, CSS3, Bootstrap 5, JavaScript
- **Images:** Local storage in wwwroot/images
- **Architecture:** Model-View-Controller (MVC)

## 📋 Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code
- Git

## 🛠️ Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Vaibhavkk435/.NET-PROJECT.git
   cd .NET-PROJECT
   ```

2. **Navigate to project directory:**
   ```bash
   cd Food-Delivery
   ```

3. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

4. **Update database:**
   ```bash
   dotnet ef database update
   ```

5. **Run the application:**
   ```bash
   dotnet run
   ```

6. **Open in browser:**
   ```
   https://localhost:5099
   ```

## 🍴 Restaurants & Menu

### 🌶️ Spice Hub
- **Location:** MG Road
- **Specialties:** Paneer Tikka (₹220), Veg Biryani (₹180)

### 🍔 Burger Bean
- **Location:** Park Street
- **Specialties:** Classic Burger (₹150)

### 🍕 Pizza Palace
- **Location:** Central Mall
- **Specialties:** Margherita Pizza (₹280), Pepperoni Pizza (₹320)

### 🍛 Curry Express
- **Location:** Food Street
- **Specialties:** Chicken Curry (₹250), Dal Tadka (₹120)

## 📁 Project Structure

```
Food-Delivery/
├── Controllers/           # MVC Controllers
│   ├── HomeController.cs
│   ├── RestaurantsController.cs
│   ├── MenuItemsController.cs
│   ├── DataController.cs
│   └── CartController.cs
├── Models/               # Data Models
│   ├── Restaurant.cs
│   ├── MenuItem.cs
│   ├── Order.cs
│   └── DataViewModel.cs
├── Views/               # Razor Views
│   ├── Home/
│   ├── Restaurants/
│   ├── MenuItems/
│   └── Shared/
├── Data/               # Database Context
│   └── AppDbContext.cs
├── Migrations/         # EF Core Migrations
├── wwwroot/           # Static Files
│   ├── css/
│   ├── js/
│   ├── images/       # Restaurant & Food Images
│   └── lib/
└── appsettings.json  # Configuration
```

## 🗄️ Database Schema

- **Restaurants** - Restaurant information with images
- **MenuItems** - Food items with prices and descriptions
- **Orders** - Customer order records
- **OrderItems** - Individual items in orders

## 🖼️ Image Assets

All images are stored locally in `wwwroot/images/`:
- Restaurant images (Pizza palace.webp, Curry palace.webp, etc.)
- Food item images (Paneer Tikka.webp, margherita pizza.jpg, etc.)

## 🚀 Deployment Options

### 1. **Azure App Service**
- Upload the `publish` folder
- Configure connection string
- Set environment variables

### 2. **Railway** (Free)
- Connect this GitHub repo
- Auto-deploys on push
- Free tier available

### 3. **Render** (Free)
- Connect GitHub repository
- Automatic builds
- Free tier with limitations

### 4. **Docker**
- Dockerfile included
- Ready for containerization

## 🌐 Live Demo

[Add your deployment URL here once deployed]

## 📊 Database Viewer

Visit `/Data` route to access the comprehensive database viewer that shows:
- All restaurants with statistics
- Complete menu items listing
- Order records and analytics
- JSON API endpoints

## 🛒 Features in Detail

### Restaurant Management
- View all restaurants with images
- Restaurant details with menu
- Dynamic loading from database

### Menu System
- Categorized menu items
- Price display in Indian Rupees (₹)
- High-quality food images
- Detailed descriptions

### Shopping Cart
- Add items to cart
- View cart contents
- Calculate totals

## 🔧 Configuration

### Database
The application uses SQLite by default. Connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=FoodDelivery.db"
  }
}
```

### Environment Variables
For production deployment:
- `ASPNETCORE_ENVIRONMENT=Production`
- `ConnectionStrings__DefaultConnection=your_production_db_string`

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Vaibhav**
- GitHub: [@Vaibhavkk435](https://github.com/Vaibhavkk435)

## 🙏 Acknowledgments

- ASP.NET Core team for the excellent framework
- Bootstrap team for the UI components
- Entity Framework team for the ORM

---

⭐ **If you like this project, please give it a star!** ⭐
