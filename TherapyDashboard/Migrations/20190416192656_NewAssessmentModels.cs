using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TherapyDashboard.Migrations
{
    public partial class NewAssessmentModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstTimePassword = table.Column<string>(nullable: true),
                    RequirePasswordResetOnNextLogin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Ethnicity = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    RelationshipStatus = table.Column<string>(nullable: true),
                    PartnerGender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParticipatingIn = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true),
                    ClientForeignKey = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Clients_ClientForeignKey",
                        column: x => x.ClientForeignKey,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CFARSAssessments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ConductDate = table.Column<DateTime>(nullable: false),
                    EnrollmentID = table.Column<int>(nullable: false),
                    ParentAssessmentID = table.Column<int>(nullable: false),
                    Answer1 = table.Column<string>(nullable: true),
                    Answer2 = table.Column<string>(nullable: true),
                    Answer3 = table.Column<string>(nullable: true),
                    Answer4 = table.Column<string>(nullable: true),
                    Answer5 = table.Column<string>(nullable: true),
                    Answer6 = table.Column<string>(nullable: true),
                    Answer7 = table.Column<string>(nullable: true),
                    Answer8 = table.Column<string>(nullable: true),
                    Answer9 = table.Column<string>(nullable: true),
                    Answer10 = table.Column<string>(nullable: true),
                    Answer11 = table.Column<string>(nullable: true),
                    Answer12 = table.Column<string>(nullable: true),
                    Answer13 = table.Column<string>(nullable: true),
                    Answer14 = table.Column<string>(nullable: true),
                    Answer15 = table.Column<string>(nullable: true),
                    Answer16 = table.Column<string>(nullable: true),
                    Answer17 = table.Column<string>(nullable: true),
                    Answer18 = table.Column<string>(nullable: true),
                    Answer19 = table.Column<string>(nullable: true),
                    Answer20 = table.Column<string>(nullable: true),
                    Answer21 = table.Column<string>(nullable: true),
                    Answer22 = table.Column<string>(nullable: true),
                    Answer23 = table.Column<string>(nullable: true),
                    Answer24 = table.Column<string>(nullable: true),
                    Answer25 = table.Column<string>(nullable: true),
                    Answer26 = table.Column<string>(nullable: true),
                    Answer27 = table.Column<string>(nullable: true),
                    Answer28 = table.Column<string>(nullable: true),
                    Answer29 = table.Column<string>(nullable: true),
                    Answer30 = table.Column<string>(nullable: true),
                    Answer31 = table.Column<string>(nullable: true),
                    Answer32 = table.Column<string>(nullable: true),
                    Answer33 = table.Column<string>(nullable: true),
                    Answer34 = table.Column<string>(nullable: true),
                    Answer35 = table.Column<string>(nullable: true),
                    Answer36 = table.Column<string>(nullable: true),
                    Answer37 = table.Column<string>(nullable: true),
                    Answer38 = table.Column<string>(nullable: true),
                    Answer39 = table.Column<string>(nullable: true),
                    Answer40 = table.Column<string>(nullable: true),
                    Answer41 = table.Column<string>(nullable: true),
                    Answer42 = table.Column<string>(nullable: true),
                    Answer43 = table.Column<string>(nullable: true),
                    Answer44 = table.Column<string>(nullable: true),
                    Answer45 = table.Column<string>(nullable: true),
                    Answer46 = table.Column<string>(nullable: true),
                    Answer47 = table.Column<string>(nullable: true),
                    Answer48 = table.Column<string>(nullable: true),
                    Answer49 = table.Column<string>(nullable: true),
                    Answer50 = table.Column<string>(nullable: true),
                    Answer51 = table.Column<string>(nullable: true),
                    Answer52 = table.Column<string>(nullable: true),
                    Answer53 = table.Column<string>(nullable: true),
                    Answer54 = table.Column<string>(nullable: true),
                    Answer55 = table.Column<string>(nullable: true),
                    Answer56 = table.Column<string>(nullable: true),
                    Answer57 = table.Column<string>(nullable: true),
                    Answer58 = table.Column<string>(nullable: true),
                    Answer59 = table.Column<string>(nullable: true),
                    Answer60 = table.Column<string>(nullable: true),
                    Answer61 = table.Column<string>(nullable: true),
                    Answer62 = table.Column<string>(nullable: true),
                    Answer63 = table.Column<string>(nullable: true),
                    Answer64 = table.Column<string>(nullable: true),
                    Answer65 = table.Column<string>(nullable: true),
                    Answer66 = table.Column<string>(nullable: true),
                    Answer67 = table.Column<string>(nullable: true),
                    Answer68 = table.Column<string>(nullable: true),
                    Answer69 = table.Column<string>(nullable: true),
                    Answer70 = table.Column<string>(nullable: true),
                    Answer71 = table.Column<string>(nullable: true),
                    Answer72 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFARSAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CFARSAssessments_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CFARSAssessments_Enrollments_EnrollmentID",
                        column: x => x.EnrollmentID,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PCLAssessments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ConductDate = table.Column<DateTime>(nullable: false),
                    EnrollmentID = table.Column<int>(nullable: false),
                    ParentAssessmentID = table.Column<int>(nullable: false),
                    Answer1 = table.Column<string>(nullable: true),
                    Answer2 = table.Column<string>(nullable: true),
                    Answer3 = table.Column<string>(nullable: true),
                    Answer4 = table.Column<string>(nullable: true),
                    Answer5 = table.Column<string>(nullable: true),
                    Answer6 = table.Column<string>(nullable: true),
                    Answer7 = table.Column<string>(nullable: true),
                    Answer8 = table.Column<string>(nullable: true),
                    Answer9 = table.Column<string>(nullable: true),
                    Answer10 = table.Column<string>(nullable: true),
                    Answer11 = table.Column<string>(nullable: true),
                    Answer12 = table.Column<string>(nullable: true),
                    Answer13 = table.Column<string>(nullable: true),
                    Answer14 = table.Column<string>(nullable: true),
                    Answer15 = table.Column<string>(nullable: true),
                    Answer16 = table.Column<string>(nullable: true),
                    Answer17 = table.Column<string>(nullable: true),
                    Answer18 = table.Column<string>(nullable: true),
                    Answer19 = table.Column<string>(nullable: true),
                    Answer20 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCLAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PCLAssessments_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PCLAssessments_Enrollments_EnrollmentID",
                        column: x => x.EnrollmentID,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PPSRAssessments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ConductDate = table.Column<DateTime>(nullable: false),
                    EnrollmentID = table.Column<int>(nullable: false),
                    ParentAssessmentID = table.Column<int>(nullable: false),
                    Answer1 = table.Column<string>(nullable: true),
                    Answer2 = table.Column<string>(nullable: true),
                    Answer3 = table.Column<string>(nullable: true),
                    Answer4 = table.Column<string>(nullable: true),
                    Answer5 = table.Column<string>(nullable: true),
                    Answer6 = table.Column<string>(nullable: true),
                    Answer7 = table.Column<string>(nullable: true),
                    Answer8 = table.Column<string>(nullable: true),
                    Answer9 = table.Column<string>(nullable: true),
                    Answer10 = table.Column<string>(nullable: true),
                    Answer11 = table.Column<string>(nullable: true),
                    Answer12 = table.Column<string>(nullable: true),
                    Answer13 = table.Column<string>(nullable: true),
                    Answer14 = table.Column<string>(nullable: true),
                    Answer15 = table.Column<string>(nullable: true),
                    Answer16 = table.Column<string>(nullable: true),
                    Answer17 = table.Column<string>(nullable: true),
                    Answer18 = table.Column<string>(nullable: true),
                    Answer19 = table.Column<string>(nullable: true),
                    Answer20 = table.Column<string>(nullable: true),
                    Answer21 = table.Column<string>(nullable: true),
                    Answer22 = table.Column<string>(nullable: true),
                    Answer23 = table.Column<string>(nullable: true),
                    Answer24 = table.Column<string>(nullable: true),
                    Answer25 = table.Column<string>(nullable: true),
                    Answer26 = table.Column<string>(nullable: true),
                    Answer27 = table.Column<string>(nullable: true),
                    Answer28 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPSRAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PPSRAssessments_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PPSRAssessments_Enrollments_EnrollmentID",
                        column: x => x.EnrollmentID,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CFARSAssessments_ClientID",
                table: "CFARSAssessments",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_CFARSAssessments_EnrollmentID",
                table: "CFARSAssessments",
                column: "EnrollmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ClientForeignKey",
                table: "Enrollments",
                column: "ClientForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_PCLAssessments_ClientID",
                table: "PCLAssessments",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_PCLAssessments_EnrollmentID",
                table: "PCLAssessments",
                column: "EnrollmentID");

            migrationBuilder.CreateIndex(
                name: "IX_PPSRAssessments_ClientID",
                table: "PPSRAssessments",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_PPSRAssessments_EnrollmentID",
                table: "PPSRAssessments",
                column: "EnrollmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CFARSAssessments");

            migrationBuilder.DropTable(
                name: "PCLAssessments");

            migrationBuilder.DropTable(
                name: "PPSRAssessments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
