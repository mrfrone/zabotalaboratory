using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace zabotalaboratory.Migrations
{
    public partial class AddUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "zabota_auth");

            migrationBuilder.RenameTable(
                name: "Jwts",
                newName: "Jwts",
                newSchema: "zabota_auth");

            migrationBuilder.RenameTable(
                name: "Identities",
                newName: "Identities",
                newSchema: "zabota_auth");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "zabota_auth",
                table: "Identities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                schema: "zabota_auth",
                table: "Identities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "zabota_auth",
                table: "Identities",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeletedById",
                schema: "zabota_auth",
                table: "Identities",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Deleted",
                schema: "zabota_auth",
                table: "Identities",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBanned",
                schema: "zabota_auth",
                table: "Identities",
                nullable: false,
                defaultValue: false);

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
                name: "IsBanned",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "Role",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.RenameTable(
                name: "Jwts",
                schema: "zabota_auth",
                newName: "Jwts");

            migrationBuilder.RenameTable(
                name: "Identities",
                schema: "zabota_auth",
                newName: "Identities");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Identities",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Identities",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Identities",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "DeletedById",
                table: "Identities",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Deleted",
                table: "Identities",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset));
        }
    }
}
