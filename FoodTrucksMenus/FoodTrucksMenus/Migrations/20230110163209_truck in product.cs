using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    public partial class truckinproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TruckId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_TruckId",
                table: "Products",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Trucks_TruckId",
                table: "Products",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Trucks_TruckId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TruckId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TruckId",
                table: "Products");
        }
    }
}
