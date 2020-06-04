using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace zabotalaboratory.Auth.Database.Migrations
{
    public partial class RemoveSubRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identities_SubRoles_SubRoleId",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.DropTable(
                name: "SubRoles",
                schema: "zabota_auth");

            migrationBuilder.DropIndex(
                name: "IX_Identities_SubRoleId",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "SubRoleId",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                schema: "zabota_auth",
                table: "Identities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClinicId",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.AddColumn<int>(
                name: "SubRoleId",
                schema: "zabota_auth",
                table: "Identities",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubRoles",
                schema: "zabota_auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsValid = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Identities_SubRoleId",
                schema: "zabota_auth",
                table: "Identities",
                column: "SubRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identities_SubRoles_SubRoleId",
                schema: "zabota_auth",
                table: "Identities",
                column: "SubRoleId",
                principalSchema: "zabota_auth",
                principalTable: "SubRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
