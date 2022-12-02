using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    public partial class menuMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Branch_BranchId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Categories_CategoryId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Truck_TruckId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Menu_MenuId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_TruckId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "TruckId",
                table: "Menu");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_CategoryId",
                table: "Menus",
                newName: "IX_Menus_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_BranchId",
                table: "Menus",
                newName: "IX_Menus_BranchId");

            migrationBuilder.AddColumn<bool>(
                name: "InOfert",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Name_BranchId",
                table: "Menus",
                columns: new[] { "Name", "BranchId" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [BranchId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Branch_BranchId",
                table: "Menus",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Categories_CategoryId",
                table: "Menus",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Menus_MenuId",
                table: "Product",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Branch_BranchId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Categories_CategoryId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Menus_MenuId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_Name_BranchId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "InOfert",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_CategoryId",
                table: "Menu",
                newName: "IX_Menu_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_BranchId",
                table: "Menu",
                newName: "IX_Menu_BranchId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TruckId",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_TruckId",
                table: "Menu",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Branch_BranchId",
                table: "Menu",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Categories_CategoryId",
                table: "Menu",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Truck_TruckId",
                table: "Menu",
                column: "TruckId",
                principalTable: "Truck",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Menu_MenuId",
                table: "Product",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id");
        }
    }
}
