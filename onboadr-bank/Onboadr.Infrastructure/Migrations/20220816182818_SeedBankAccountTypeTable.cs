using Microsoft.EntityFrameworkCore.Migrations;

namespace Onboadr.Infrastructure.Migrations
{
    public partial class SeedBankAccountTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO BankAccountTypes (Id, Name) VALUES (1, 'Savings')");
            migrationBuilder.Sql("INSERT INTO BankAccountTypes (Id, Name) VALUES (2, 'Current')");
            migrationBuilder.Sql("INSERT INTO BankAccountTypes (Id, Name) VALUES (3, 'Domiciliary' )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
