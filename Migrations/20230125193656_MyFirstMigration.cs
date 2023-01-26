using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblcategory",
                columns: table => new
                {
                    Categoryid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcategory", x => x.Categoryid);
                });

            migrationBuilder.CreateTable(
                name: "tblcomplaints",
                columns: table => new
                {
                    Complaintid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    subject = table.Column<string>(nullable: true),
                    message = table.Column<string>(nullable: true),
                    Registrationid = table.Column<int>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcomplaints", x => x.Complaintid);
                });

            migrationBuilder.CreateTable(
                name: "tblcountry",
                columns: table => new
                {
                    Countryid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Countryname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcountry", x => x.Countryid);
                });

            migrationBuilder.CreateTable(
                name: "tbldesc",
                columns: table => new
                {
                    Descid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoryid = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    Registrationid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbldesc", x => x.Descid);
                });

            migrationBuilder.CreateTable(
                name: "tblregistration",
                columns: table => new
                {
                    Registrationid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Dob = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblregistration", x => x.Registrationid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblcategory");

            migrationBuilder.DropTable(
                name: "tblcomplaints");

            migrationBuilder.DropTable(
                name: "tblcountry");

            migrationBuilder.DropTable(
                name: "tbldesc");

            migrationBuilder.DropTable(
                name: "tblregistration");
        }
    }
}
