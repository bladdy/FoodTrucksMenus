using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    public partial class Truckplatforms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TruckPlatform_Platforms_PlatformId",
                table: "TruckPlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_TruckPlatform_Trucks_TruckId",
                table: "TruckPlatform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TruckPlatform",
                table: "TruckPlatform");

            migrationBuilder.RenameTable(
                name: "TruckPlatform",
                newName: "TruckPlatforms");

            migrationBuilder.RenameIndex(
                name: "IX_TruckPlatform_TruckId",
                table: "TruckPlatforms",
                newName: "IX_TruckPlatforms_TruckId");

            migrationBuilder.RenameIndex(
                name: "IX_TruckPlatform_PlatformId",
                table: "TruckPlatforms",
                newName: "IX_TruckPlatforms_PlatformId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TruckPlatforms",
                table: "TruckPlatforms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckPlatforms_Platforms_PlatformId",
                table: "TruckPlatforms",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckPlatforms_Trucks_TruckId",
                table: "TruckPlatforms",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TruckPlatforms_Platforms_PlatformId",
                table: "TruckPlatforms");

            migrationBuilder.DropForeignKey(
                name: "FK_TruckPlatforms_Trucks_TruckId",
                table: "TruckPlatforms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TruckPlatforms",
                table: "TruckPlatforms");

            migrationBuilder.RenameTable(
                name: "TruckPlatforms",
                newName: "TruckPlatform");

            migrationBuilder.RenameIndex(
                name: "IX_TruckPlatforms_TruckId",
                table: "TruckPlatform",
                newName: "IX_TruckPlatform_TruckId");

            migrationBuilder.RenameIndex(
                name: "IX_TruckPlatforms_PlatformId",
                table: "TruckPlatform",
                newName: "IX_TruckPlatform_PlatformId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TruckPlatform",
                table: "TruckPlatform",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckPlatform_Platforms_PlatformId",
                table: "TruckPlatform",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckPlatform_Trucks_TruckId",
                table: "TruckPlatform",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id");
        }
    }
}
