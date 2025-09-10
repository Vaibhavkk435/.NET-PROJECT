using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Food_Delivery.Migrations
{
    /// <inheritdoc />
    public partial class AddNewRestaurants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 3, "Central Mall", "/images/burger-pic.avif", "Pizza Palace" },
                    { 4, "Food Street", "/images/spice lab.jpg", "Curry Express" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 4, "Fresh tomato sauce, mozzarella, and basil", "/images/burger-pic.avif", "Margherita Pizza", 280m, 3 },
                    { 5, "Classic pepperoni with mozzarella cheese", "/images/burger-pic.avif", "Pepperoni Pizza", 320m, 3 },
                    { 6, "Tender chicken in rich spicy gravy", "/images/Paneer Tikka.webp", "Chicken Curry", 250m, 4 },
                    { 7, "Yellow lentils with aromatic spices", "/images/Veg Biryani.webp", "Dal Tadka", 120m, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
