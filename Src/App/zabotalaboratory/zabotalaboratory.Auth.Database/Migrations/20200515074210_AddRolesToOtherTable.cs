using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace zabotalaboratory.Auth.Database.Migrations
{
    public partial class AddRolesToOtherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                schema: "zabota_auth",
                table: "Identities");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "zabota_auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "zabota_auth",
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Администратор" },
                    { 2, "Лаборант" },
                    { 3, "Поликлиника" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles",
                schema: "zabota_auth");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                schema: "zabota_auth",
                table: "Identities",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
