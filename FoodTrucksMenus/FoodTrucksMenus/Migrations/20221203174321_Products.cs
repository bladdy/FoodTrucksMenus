using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    public partial class Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Menus_MenuId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_MenuId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_MenuId",
                table: "Product",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Menus_MenuId",
                table: "Product",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");
        }
    }
}
