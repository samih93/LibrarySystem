using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApi.Migrations
{
    public partial class changenametorececeipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailsFactures");

            migrationBuilder.RenameColumn(
                name: "facturePrice",
                table: "Receipts",
                newName: "receiptPrice");

            migrationBuilder.RenameColumn(
                name: "factureDate",
                table: "Receipts",
                newName: "receiptDate");

            migrationBuilder.CreateTable(
                name: "DetailsReceipts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    receiptId = table.Column<int>(type: "int", nullable: false),
                    totalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsReceipts", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetailsReceipts_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsReceipts_Receipts_receiptId",
                        column: x => x.receiptId,
                        principalTable: "Receipts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailsReceipts_productId",
                table: "DetailsReceipts",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsReceipts_receiptId",
                table: "DetailsReceipts",
                column: "receiptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailsReceipts");

            migrationBuilder.RenameColumn(
                name: "receiptPrice",
                table: "Receipts",
                newName: "facturePrice");

            migrationBuilder.RenameColumn(
                name: "receiptDate",
                table: "Receipts",
                newName: "factureDate");

            migrationBuilder.CreateTable(
                name: "DetailsFactures",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    receiptId = table.Column<int>(type: "int", nullable: false),
                    totalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsFactures", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetailsFactures_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsFactures_Receipts_receiptId",
                        column: x => x.receiptId,
                        principalTable: "Receipts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailsFactures_productId",
                table: "DetailsFactures",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsFactures_receiptId",
                table: "DetailsFactures",
                column: "receiptId");
        }
    }
}
