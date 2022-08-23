using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onboadr.Infrastructure.Migrations
{
    public partial class AddTimeOTPCodeGenToOTPInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "timeOTPCodeGen",
                table: "OTPInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "timeOTPCodeGen",
                table: "OTPInfos");
        }
    }
}
