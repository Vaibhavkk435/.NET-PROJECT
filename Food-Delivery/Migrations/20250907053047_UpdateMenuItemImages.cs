using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Delivery.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenuItemImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/Veg Biryani.webp");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/Burger bean.webp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: null);
        }
    }
}
