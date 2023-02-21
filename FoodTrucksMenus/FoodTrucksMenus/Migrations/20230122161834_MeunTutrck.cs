using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    public partial class MeunTutrck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TruckId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MenuBranchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuBranchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuBranchs_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuBranchs_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_TruckId",
                table: "Menus",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuBranchs_BranchId",
                table: "MenuBranchs",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuBranchs_MenuId",
                table: "MenuBranchs",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Trucks_TruckId",
                table: "Menus",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Trucks_TruckId",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "MenuBranchs");

            migrationBuilder.DropIndex(
                name: "IX_Menus_TruckId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "TruckId",
                table: "Menus");
        }
    }
}
