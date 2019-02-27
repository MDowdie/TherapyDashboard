using Microsoft.EntityFrameworkCore.Migrations;

namespace TherapyDashboard.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Clients_ClientId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_ClientId",
                table: "Enrollments");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Enrollments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientForeignKey",
                table: "Enrollments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ClientForeignKey",
                table: "Enrollments",
                column: "ClientForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Clients_ClientForeignKey",
                table: "Enrollments",
                column: "ClientForeignKey",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Clients_ClientForeignKey",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_ClientForeignKey",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "ClientForeignKey",
                table: "Enrollments");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Enrollments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ClientId",
                table: "Enrollments",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Clients_ClientId",
                table: "Enrollments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
