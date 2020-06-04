using Microsoft.EntityFrameworkCore.Migrations;

namespace zabotalaboratory.Auth.Database.Migrations
{
    public partial class AddClinicNameToIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClinicName",
                schema: "zabota_auth",
                table: "Identities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClinicName",
                schema: "zabota_auth",
                table: "Identities");
        }
    }
}
