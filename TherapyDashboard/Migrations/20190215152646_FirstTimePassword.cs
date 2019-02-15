using Microsoft.EntityFrameworkCore.Migrations;

namespace TherapyDashboard.Migrations
{
    public partial class FirstTimePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstTimePassword",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstTimePassword",
                table: "AspNetUsers");
        }
    }
}
