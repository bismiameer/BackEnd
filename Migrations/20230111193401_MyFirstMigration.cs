using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblcomplaints",
                columns: table => new
                {
                    Complaintid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    subject = table.Column<string>(nullable: true),
                    message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcomplaints", x => x.Complaintid);
                });

            migrationBuilder.CreateTable(
                name: "tblregistration",
                columns: table => new
                {
                    Registrationid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Dob = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblregistration", x => x.Registrationid);
                });

            migrationBuilder.CreateTable(
                name: "uploads",
                columns: table => new
                {
                    Uploadsid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category = table.Column<string>(nullable: true),
                    videofile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uploads", x => x.Uploadsid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblcomplaints");

            migrationBuilder.DropTable(
                name: "tblregistration");

            migrationBuilder.DropTable(
                name: "uploads");
        }
    }
}
