using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApi.Migrations
{
    public partial class changefacturename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactures_Factures_factureId",
                table: "DetailsFactures");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropIndex(
                name: "IX_DetailsFactures_factureId",
                table: "DetailsFactures");

            migrationBuilder.AddColumn<int>(
                name: "receiptid",
                table: "DetailsFactures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    facturePrice = table.Column<double>(type: "float", nullable: false),
                    factureDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailsFactures_receiptid",
                table: "DetailsFactures",
                column: "receiptid");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactures_Receipts_receiptid",
                table: "DetailsFactures",
                column: "receiptid",
                principalTable: "Receipts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactures_Receipts_receiptid",
                table: "DetailsFactures");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_DetailsFactures_receiptid",
                table: "DetailsFactures");

            migrationBuilder.DropColumn(
                name: "receiptid",
                table: "DetailsFactures");

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    factureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    facturePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailsFactures_factureId",
                table: "DetailsFactures",
                column: "factureId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactures_Factures_factureId",
                table: "DetailsFactures",
                column: "factureId",
                principalTable: "Factures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
