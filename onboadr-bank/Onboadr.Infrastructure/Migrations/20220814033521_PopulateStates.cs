using Microsoft.EntityFrameworkCore.Migrations;

namespace Onboadr.Infrastructure.Migrations
{
    public partial class PopulateStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Abia')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Adamawa')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Akwa Ibom')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Anambra')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Bauchi')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Bayelsa')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Benue')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Borno')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Cross River')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Delta')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Ebonyi')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Edo')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Ekiti')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Enugu')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('FCT')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Gombe')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Imo')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Jigawa')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Kaduna')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Kano')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Katsina')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Kebbi')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Kogi')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Kwara')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Lagos')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Nasarawa')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Niger')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Ogun')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Ondo')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Osun')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Oyo')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Plateau')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Rivers')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Sokoto')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Taraba')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Yobe')");
            migrationBuilder.Sql("INSERT INTO States(Name) VALUES('Zamfara')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
