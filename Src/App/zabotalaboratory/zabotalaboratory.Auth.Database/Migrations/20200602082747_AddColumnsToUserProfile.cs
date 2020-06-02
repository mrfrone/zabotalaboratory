using Microsoft.EntityFrameworkCore.Migrations;

namespace zabotalaboratory.Auth.Database.Migrations
{
    public partial class AddColumnsToUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "zabota_auth",
                table: "UsersProfiles");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "zabota_auth",
                table: "UsersProfiles");

            migrationBuilder.DropColumn(
                name: "PatronymicName",
                schema: "zabota_auth",
                table: "UsersProfiles");

            migrationBuilder.AddColumn<string>(
                name: "AbbreviatedNameOfCompany",
                schema: "zabota_auth",
                table: "UsersProfiles",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "zabota_auth",
                table: "UsersProfiles",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullNameOfCompany",
                schema: "zabota_auth",
                table: "UsersProfiles",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "zabota_auth",
                table: "SubRoles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "zabota_auth",
                table: "Roles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbbreviatedNameOfCompany",
                schema: "zabota_auth",
                table: "UsersProfiles");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "zabota_auth",
                table: "UsersProfiles");

            migrationBuilder.DropColumn(
                name: "FullNameOfCompany",
                schema: "zabota_auth",
                table: "UsersProfiles");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "zabota_auth",
                table: "UsersProfiles",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "zabota_auth",
                table: "UsersProfiles",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatronymicName",
                schema: "zabota_auth",
                table: "UsersProfiles",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "zabota_auth",
                table: "SubRoles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "zabota_auth",
                table: "Roles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
