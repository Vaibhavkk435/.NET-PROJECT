using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Delivery.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAllMenuItemPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/margherita pizza.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/Pepproni pizza.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/images/Chicken Curry.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/images/Dal.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/burger-pic.avif");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/burger-pic.avif");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/images/Paneer Tikka.webp");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/images/Veg Biryani.webp");
        }
    }
}
