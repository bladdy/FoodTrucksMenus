using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    public partial class UNIQUEtruckplatform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TruckPlatforms_TruckId",
                table: "TruckPlatforms");

            migrationBuilder.CreateIndex(
                name: "IX_TruckPlatforms_TruckId_PlatformId",
                table: "TruckPlatforms",
                columns: new[] { "TruckId", "PlatformId" },
                unique: true,
                filter: "[TruckId] IS NOT NULL AND [PlatformId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TruckPlatforms_TruckId_PlatformId",
                table: "TruckPlatforms");

            migrationBuilder.CreateIndex(
                name: "IX_TruckPlatforms_TruckId",
                table: "TruckPlatforms",
                column: "TruckId");
        }
    }
}
