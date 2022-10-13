using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApi.Migrations
{
    public partial class addqtytoproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "qty",
                table: "DetailsFactures");

            migrationBuilder.AddColumn<double>(
                name: "qty",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "qty",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "qty",
                table: "DetailsFactures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
