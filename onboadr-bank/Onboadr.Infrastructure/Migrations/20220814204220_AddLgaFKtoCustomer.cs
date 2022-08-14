using Microsoft.EntityFrameworkCore.Migrations;

namespace Onboadr.Infrastructure.Migrations
{
    public partial class AddLgaFKtoCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LgaId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LgaId",
                table: "Customers",
                column: "LgaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Lgas_LgaId",
                table: "Customers",
                column: "LgaId",
                principalTable: "Lgas",
                principalColumn: "LgaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Lgas_LgaId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LgaId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LgaId",
                table: "Customers");
        }
    }
}
