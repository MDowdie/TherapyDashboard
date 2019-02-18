using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TherapyDashboard.Migrations
{
    public partial class TagRemoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Tags_PartnerGenderId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "ClientTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Clients_PartnerGenderId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PartnerGenderId",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Ethnicity",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartnerGender",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ethnicity",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PartnerGender",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "PartnerGenderId",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TagType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientTags",
                columns: table => new
                {
                    ClientId = table.Column<string>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTags", x => new { x.ClientId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ClientTags_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PartnerGenderId",
                table: "Clients",
                column: "PartnerGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTags_TagId",
                table: "ClientTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Tags_PartnerGenderId",
                table: "Clients",
                column: "PartnerGenderId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
