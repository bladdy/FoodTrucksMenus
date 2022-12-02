using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    public partial class estruccturaTrckbranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Truck");

            migrationBuilder.DropColumn(
                name: "TablesNumbers",
                table: "Truck");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Table",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBranch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    TablesNumbers = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    TruckId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branch_Truck_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Truck",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Table_BranchId",
                table: "Table",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BranchId",
                table: "Order",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_BranchId",
                table: "Menu",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CityId",
                table: "Branch",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_TruckId",
                table: "Branch",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Branch_BranchId",
                table: "Menu",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Branch_BranchId",
                table: "Order",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Branch_BranchId",
                table: "Table",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Branch_BranchId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Branch_BranchId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_Branch_BranchId",
                table: "Table");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_Table_BranchId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Order_BranchId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Menu_BranchId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Menu");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Truck",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TablesNumbers",
                table: "Truck",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
