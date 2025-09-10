using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Delivery.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewRestaurantImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/Pizza palace.webp");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/Curry palace.webp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/burger-pic.avif");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/spice lab.jpg");
        }
    }
}
