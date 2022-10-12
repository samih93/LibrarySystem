using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApi.Migrations
{
    public partial class addcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactures_Factures_FactureId",
                table: "DetailsFactures");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactures_Products_ProductId",
                table: "DetailsFactures");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Stocks",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stocks",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                newName: "IX_Stocks_productId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FacturePrice",
                table: "Factures",
                newName: "facturePrice");

            migrationBuilder.RenameColumn(
                name: "FactureDate",
                table: "Factures",
                newName: "factureDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Factures",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "DetailsFactures",
                newName: "totalPrice");

            migrationBuilder.RenameColumn(
                name: "Qty",
                table: "DetailsFactures",
                newName: "qty");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "DetailsFactures",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "FactureId",
                table: "DetailsFactures",
                newName: "factureId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DetailsFactures",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_DetailsFactures_ProductId",
                table: "DetailsFactures",
                newName: "IX_DetailsFactures_productId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailsFactures_FactureId",
                table: "DetailsFactures",
                newName: "IX_DetailsFactures_factureId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactures_Factures_factureId",
                table: "DetailsFactures",
                column: "factureId",
                principalTable: "Factures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactures_Products_productId",
                table: "DetailsFactures",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Products_productId",
                table: "Stocks",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactures_Factures_factureId",
                table: "DetailsFactures");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactures_Products_productId",
                table: "DetailsFactures");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Products_productId",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Stocks",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Stocks",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_productId",
                table: "Stocks",
                newName: "IX_Stocks_ProductId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "facturePrice",
                table: "Factures",
                newName: "FacturePrice");

            migrationBuilder.RenameColumn(
                name: "factureDate",
                table: "Factures",
                newName: "FactureDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Factures",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "totalPrice",
                table: "DetailsFactures",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "qty",
                table: "DetailsFactures",
                newName: "Qty");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "DetailsFactures",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "factureId",
                table: "DetailsFactures",
                newName: "FactureId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DetailsFactures",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_DetailsFactures_productId",
                table: "DetailsFactures",
                newName: "IX_DetailsFactures_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailsFactures_factureId",
                table: "DetailsFactures",
                newName: "IX_DetailsFactures_FactureId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactures_Factures_FactureId",
                table: "DetailsFactures",
                column: "FactureId",
                principalTable: "Factures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactures_Products_ProductId",
                table: "DetailsFactures",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
