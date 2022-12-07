using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    public partial class ModificacionPrecioOferta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuProducts_Menus_MenuId",
                table: "MenuProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuProducts_Products_ProductId",
                table: "MenuProducts");

            migrationBuilder.DropIndex(
                name: "IX_MenuProducts_MenuId_ProductId",
                table: "MenuProducts");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceOfert",
                table: "Products",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "MenuProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MenuProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuProducts_MenuId_ProductId",
                table: "MenuProducts",
                columns: new[] { "MenuId", "ProductId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuProducts_Menus_MenuId",
                table: "MenuProducts",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuProducts_Products_ProductId",
                table: "MenuProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuProducts_Menus_MenuId",
                table: "MenuProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuProducts_Products_ProductId",
                table: "MenuProducts");

            migrationBuilder.DropIndex(
                name: "IX_MenuProducts_MenuId_ProductId",
                table: "MenuProducts");

            migrationBuilder.DropColumn(
                name: "PriceOfert",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "MenuProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MenuProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MenuProducts_MenuId_ProductId",
                table: "MenuProducts",
                columns: new[] { "MenuId", "ProductId" },
                unique: true,
                filter: "[MenuId] IS NOT NULL AND [ProductId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuProducts_Menus_MenuId",
                table: "MenuProducts",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuProducts_Products_ProductId",
                table: "MenuProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
