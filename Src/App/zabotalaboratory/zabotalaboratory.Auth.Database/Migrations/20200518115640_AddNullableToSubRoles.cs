using Microsoft.EntityFrameworkCore.Migrations;

namespace zabotalaboratory.Auth.Database.Migrations
{
    public partial class AddNullableToSubRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identities_SubRoles_SubRoleId",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.DeleteData(
                schema: "zabota_auth",
                table: "SubRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "SubRoleId",
                schema: "zabota_auth",
                table: "Identities",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identities_SubRoles_SubRoleId",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.AlterColumn<int>(
                name: "SubRoleId",
                schema: "zabota_auth",
                table: "Identities",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "zabota_auth",
                table: "SubRoles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Все" });

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
    }
}
