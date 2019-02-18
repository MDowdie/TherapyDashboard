using Microsoft.EntityFrameworkCore.Migrations;

namespace TherapyDashboard.Migrations
{
    public partial class ComplexDataModelFixNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Tags_PartnerGenderId",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "RelationshipStatus",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "PartnerGenderId",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Tags_PartnerGenderId",
                table: "Clients",
                column: "PartnerGenderId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Tags_PartnerGenderId",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "RelationshipStatus",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PartnerGenderId",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Tags_PartnerGenderId",
                table: "Clients",
                column: "PartnerGenderId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
