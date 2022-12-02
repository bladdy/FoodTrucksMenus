using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    public partial class menucreateing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Cities_CityId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Truck_TruckId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Branch_BranchId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Branch_BranchId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Truck_TruckId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_Branch_BranchId",
                table: "Table");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_Truck_TruckId",
                table: "Table");

            migrationBuilder.DropForeignKey(
                name: "FK_TruckCategory_Truck_TruckId",
                table: "TruckCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_TruckPlatform_Truck_TruckId",
                table: "TruckPlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_TruckSchedule_Truck_TruckId",
                table: "TruckSchedule");

            migrationBuilder.DropIndex(
                name: "IX_Menus_Name_BranchId",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Truck",
                table: "Truck");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branch",
                table: "Branch");

            migrationBuilder.RenameTable(
                name: "Truck",
                newName: "Trucks");

            migrationBuilder.RenameTable(
                name: "Branch",
                newName: "Branches");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_TruckId",
                table: "Branches",
                newName: "IX_Branches_TruckId");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_CityId",
                table: "Branches",
                newName: "IX_Branches_CityId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nametruck",
                table: "Trucks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TruckId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trucks",
                table: "Trucks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Name_BranchId_CategoryId",
                table: "Menus",
                columns: new[] { "Name", "BranchId", "CategoryId" },
                unique: true,
                filter: "[BranchId] IS NOT NULL AND [CategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_Nametruck",
                table: "Trucks",
                column: "Nametruck",
                unique: true,
                filter: "[Nametruck] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_NameBranch_TruckId",
                table: "Branches",
                columns: new[] { "NameBranch", "TruckId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Cities_CityId",
                table: "Branches",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Trucks_TruckId",
                table: "Branches",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Branches_BranchId",
                table: "Menus",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Branches_BranchId",
                table: "Order",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Trucks_TruckId",
                table: "Order",
                column: "TruckId",
                principalTable: "Trucks",
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

            migrationBuilder.AddForeignKey(
                name: "FK_TruckCategory_Trucks_TruckId",
                table: "TruckCategory",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckPlatform_Trucks_TruckId",
                table: "TruckPlatform",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckSchedule_Trucks_TruckId",
                table: "TruckSchedule",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Cities_CityId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Trucks_TruckId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Branches_BranchId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Branches_BranchId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Trucks_TruckId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_Branches_BranchId",
                table: "Table");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_Trucks_TruckId",
                table: "Table");

            migrationBuilder.DropForeignKey(
                name: "FK_TruckCategory_Trucks_TruckId",
                table: "TruckCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_TruckPlatform_Trucks_TruckId",
                table: "TruckPlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_TruckSchedule_Trucks_TruckId",
                table: "TruckSchedule");

            migrationBuilder.DropIndex(
                name: "IX_Menus_Name_BranchId_CategoryId",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trucks",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Trucks_Nametruck",
                table: "Trucks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_NameBranch_TruckId",
                table: "Branches");

            migrationBuilder.RenameTable(
                name: "Trucks",
                newName: "Truck");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "Branch");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_TruckId",
                table: "Branch",
                newName: "IX_Branch_TruckId");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_CityId",
                table: "Branch",
                newName: "IX_Branch_CityId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nametruck",
                table: "Truck",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TruckId",
                table: "Branch",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Truck",
                table: "Truck",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branch",
                table: "Branch",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Name_BranchId",
                table: "Menus",
                columns: new[] { "Name", "BranchId" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [BranchId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Cities_CityId",
                table: "Branch",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Truck_TruckId",
                table: "Branch",
                column: "TruckId",
                principalTable: "Truck",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Branch_BranchId",
                table: "Menus",
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
                name: "FK_Order_Truck_TruckId",
                table: "Order",
                column: "TruckId",
                principalTable: "Truck",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Branch_BranchId",
                table: "Table",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Truck_TruckId",
                table: "Table",
                column: "TruckId",
                principalTable: "Truck",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckCategory_Truck_TruckId",
                table: "TruckCategory",
                column: "TruckId",
                principalTable: "Truck",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckPlatform_Truck_TruckId",
                table: "TruckPlatform",
                column: "TruckId",
                principalTable: "Truck",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckSchedule_Truck_TruckId",
                table: "TruckSchedule",
                column: "TruckId",
                principalTable: "Truck",
                principalColumn: "Id");
        }
    }
}
