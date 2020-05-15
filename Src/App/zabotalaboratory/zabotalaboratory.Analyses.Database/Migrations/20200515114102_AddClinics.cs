using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace zabotalaboratory.Analyses.Database.Migrations
{
    public partial class AddClinics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "zabota_analyses");

            migrationBuilder.CreateTable(
                name: "Clinics",
                schema: "zabota_analyses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "zabota_analyses",
                table: "Clinics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Все" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clinics",
                schema: "zabota_analyses");
        }
    }
}
