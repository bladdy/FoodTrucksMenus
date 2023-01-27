using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    public partial class branchs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Table_TableId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_Branches_BranchId",
                table: "Table");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_Trucks_TruckId",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Table",
                table: "Table");

            migrationBuilder.RenameTable(
                name: "Table",
                newName: "Tables");

            migrationBuilder.RenameIndex(
                name: "IX_Table_TruckId",
                table: "Tables",
                newName: "IX_Tables_TruckId");

            migrationBuilder.RenameIndex(
                name: "IX_Table_BranchId",
                table: "Tables",
                newName: "IX_Tables_BranchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Tables_TableId",
                table: "Order",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Branches_BranchId",
                table: "Tables",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Trucks_TruckId",
                table: "Tables",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Tables_TableId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Branches_BranchId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Trucks_TruckId",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "Table");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_TruckId",
                table: "Table",
                newName: "IX_Table_TruckId");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_BranchId",
                table: "Table",
                newName: "IX_Table_BranchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Table",
                table: "Table",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Table_TableId",
                table: "Order",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Branches_BranchId",
                table: "Table",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Trucks_TruckId",
                table: "Table",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id");
        }
    }
}
