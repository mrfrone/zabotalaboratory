using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace zabotalaboratory.Auth.Database.Migrations
{
    public partial class AddRolesAndSubRolesToIdentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                schema: "zabota_auth",
                table: "Identities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubRoleId",
                schema: "zabota_auth",
                table: "Identities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SubRoles",
                schema: "zabota_auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRoles", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "zabota_auth",
                table: "SubRoles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Все" });

            migrationBuilder.CreateIndex(
                name: "IX_Identities_RoleId",
                schema: "zabota_auth",
                table: "Identities",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Identities_SubRoleId",
                schema: "zabota_auth",
                table: "Identities",
                column: "SubRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identities_Roles_RoleId",
                schema: "zabota_auth",
                table: "Identities",
                column: "RoleId",
                principalSchema: "zabota_auth",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Identities_SubRoles_SubRoleId",
                schema: "zabota_auth",
                table: "Identities",
                column: "SubRoleId",
                principalSchema: "zabota_auth",
                principalTable: "SubRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identities_Roles_RoleId",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.DropForeignKey(
                name: "FK_Identities_SubRoles_SubRoleId",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.DropTable(
                name: "SubRoles",
                schema: "zabota_auth");

            migrationBuilder.DropIndex(
                name: "IX_Identities_RoleId",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.DropIndex(
                name: "IX_Identities_SubRoleId",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "RoleId",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "SubRoleId",
                schema: "zabota_auth",
                table: "Identities");
        }
    }
}
