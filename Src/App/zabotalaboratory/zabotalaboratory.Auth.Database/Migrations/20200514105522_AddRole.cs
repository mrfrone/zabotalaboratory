using Microsoft.EntityFrameworkCore.Migrations;

namespace zabotalaboratory.Auth.Database.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                schema: "zabota_auth",
                table: "Identities",
                nullable: false,
                defaultValue: "");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersProfiles",
                schema: "zabota_auth");

            migrationBuilder.DropColumn(
                name: "Role",
                schema: "zabota_auth",
                table: "Identities");
        }
    }
}
