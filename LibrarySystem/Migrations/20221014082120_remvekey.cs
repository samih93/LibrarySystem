using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApi.Migrations
{
    public partial class remvekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailsReceipts",
                table: "DetailsReceipts");

            migrationBuilder.DropIndex(
                name: "IX_DetailsReceipts_productId",
                table: "DetailsReceipts");

            migrationBuilder.DropColumn(
                name: "id",
                table: "DetailsReceipts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailsReceipts",
                table: "DetailsReceipts",
                columns: new[] { "productId", "receiptId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailsReceipts",
                table: "DetailsReceipts");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "DetailsReceipts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailsReceipts",
                table: "DetailsReceipts",
                columns: new[] { "id", "productId", "receiptId" });

            migrationBuilder.CreateIndex(
                name: "IX_DetailsReceipts_productId",
                table: "DetailsReceipts",
                column: "productId");
        }
    }
}
