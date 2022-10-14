using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApi.Migrations
{
    public partial class setkeytodetailsreceipt1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailsReceipts",
                table: "DetailsReceipts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailsReceipts",
                table: "DetailsReceipts",
                columns: new[] { "id", "productId", "receiptId" });

            migrationBuilder.CreateIndex(
                name: "IX_DetailsReceipts_productId",
                table: "DetailsReceipts",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailsReceipts",
                table: "DetailsReceipts");

            migrationBuilder.DropIndex(
                name: "IX_DetailsReceipts_productId",
                table: "DetailsReceipts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailsReceipts",
                table: "DetailsReceipts",
                columns: new[] { "productId", "receiptId" });
        }
    }
}
