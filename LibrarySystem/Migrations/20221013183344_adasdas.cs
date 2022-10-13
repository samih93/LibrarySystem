using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApi.Migrations
{
    public partial class adasdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactures_Receipts_receiptid",
                table: "DetailsFactures");

            migrationBuilder.DropColumn(
                name: "factureId",
                table: "DetailsFactures");

            migrationBuilder.RenameColumn(
                name: "receiptid",
                table: "DetailsFactures",
                newName: "receiptId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailsFactures_receiptid",
                table: "DetailsFactures",
                newName: "IX_DetailsFactures_receiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactures_Receipts_receiptId",
                table: "DetailsFactures",
                column: "receiptId",
                principalTable: "Receipts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactures_Receipts_receiptId",
                table: "DetailsFactures");

            migrationBuilder.RenameColumn(
                name: "receiptId",
                table: "DetailsFactures",
                newName: "receiptid");

            migrationBuilder.RenameIndex(
                name: "IX_DetailsFactures_receiptId",
                table: "DetailsFactures",
                newName: "IX_DetailsFactures_receiptid");

            migrationBuilder.AddColumn<int>(
                name: "factureId",
                table: "DetailsFactures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactures_Receipts_receiptid",
                table: "DetailsFactures",
                column: "receiptid",
                principalTable: "Receipts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
