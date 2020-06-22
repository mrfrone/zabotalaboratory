using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace zabotalaboratory.Analyses.Database.Migrations
{
    public partial class NewNameColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceLimits",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.DropColumn(
                name: "Units",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.AddColumn<string>(
                name: "ExcelName",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberInOrder",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PDFName",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExcelName",
                schema: "zabota_analyses",
                table: "AnalysesTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberInOrder",
                schema: "zabota_analyses",
                table: "AnalysesTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PDFName",
                schema: "zabota_analyses",
                table: "AnalysesTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceLimits",
                schema: "zabota_analyses",
                table: "AnalysesResult",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Units",
                schema: "zabota_analyses",
                table: "AnalysesResult",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gender",
                schema: "zabota_analyses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "zabota_analyses",
                table: "Gender",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "Мужской", "M" },
                    { 2, "Женский", "F" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryAnalyses_GenderId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryAnalyses_Gender_GenderId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                column: "GenderId",
                principalSchema: "zabota_analyses",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryAnalyses_Gender_GenderId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses");

            migrationBuilder.DropTable(
                name: "Gender",
                schema: "zabota_analyses");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryAnalyses_GenderId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses");

            migrationBuilder.DropColumn(
                name: "ExcelName",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.DropColumn(
                name: "NumberInOrder",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.DropColumn(
                name: "PDFName",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.DropColumn(
                name: "GenderId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses");

            migrationBuilder.DropColumn(
                name: "ExcelName",
                schema: "zabota_analyses",
                table: "AnalysesTypes");

            migrationBuilder.DropColumn(
                name: "NumberInOrder",
                schema: "zabota_analyses",
                table: "AnalysesTypes");

            migrationBuilder.DropColumn(
                name: "PDFName",
                schema: "zabota_analyses",
                table: "AnalysesTypes");

            migrationBuilder.DropColumn(
                name: "ReferenceLimits",
                schema: "zabota_analyses",
                table: "AnalysesResult");

            migrationBuilder.DropColumn(
                name: "Units",
                schema: "zabota_analyses",
                table: "AnalysesResult");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceLimits",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Units",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                type: "text",
                nullable: true);
        }
    }
}
