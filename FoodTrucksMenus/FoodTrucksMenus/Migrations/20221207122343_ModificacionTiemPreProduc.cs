using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    public partial class ModificacionTiemPreProduc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagenProduct",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrepTime",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrepTime",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImagenProduct",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
