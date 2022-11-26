using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    public partial class categoryTableRe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_NameCat",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "NameCat",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NameCat",
                table: "Categories",
                column: "NameCat",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_NameCat",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "NameCat",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NameCat",
                table: "Categories",
                column: "NameCat",
                unique: true,
                filter: "[NameCat] IS NOT NULL");
        }
    }
}
