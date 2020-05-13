using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace zabotalaboratory.Auth.Database.Migrations
{
    public partial class AddAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "zabota_auth");

            migrationBuilder.CreateTable(
                name: "Identities",
                schema: "zabota_auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    IsBanned = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    DeletedById = table.Column<int>(nullable: true),
                    Deleted = table.Column<DateTimeOffset>(nullable: true),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jwts",
                schema: "zabota_auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(nullable: true),
                    Expires = table.Column<DateTimeOffset>(nullable: false),
                    Issued = table.Column<DateTimeOffset>(nullable: false),
                    Deleted = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IdentityId = table.Column<int>(nullable: false),
                    DeletedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jwts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jwts_Identities_DeletedById",
                        column: x => x.DeletedById,
                        principalSchema: "zabota_auth",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jwts_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "zabota_auth",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersProfiles",
                schema: "zabota_auth",
                columns: table => new
                {
                    IdentityId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 32, nullable: false),
                    LastName = table.Column<string>(maxLength: 32, nullable: false),
                    PatronymicName = table.Column<string>(maxLength: 32, nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProfiles", x => x.IdentityId);
                    table.ForeignKey(
                        name: "FK_UsersProfiles_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "zabota_auth",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Identities_Login",
                schema: "zabota_auth",
                table: "Identities",
                column: "Login")
                .Annotation("Npgsql:IndexInclude", new[] { "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Jwts_DeletedById",
                schema: "zabota_auth",
                table: "Jwts",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Jwts_IdentityId",
                schema: "zabota_auth",
                table: "Jwts",
                column: "IdentityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jwts",
                schema: "zabota_auth");

            migrationBuilder.DropTable(
                name: "UsersProfiles",
                schema: "zabota_auth");

            migrationBuilder.DropTable(
                name: "Identities",
                schema: "zabota_auth");
        }
    }
}
