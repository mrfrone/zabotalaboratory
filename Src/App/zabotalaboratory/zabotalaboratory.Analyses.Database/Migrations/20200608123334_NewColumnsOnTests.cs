using Microsoft.EntityFrameworkCore.Migrations;

namespace zabotalaboratory.Analyses.Database.Migrations
{
    public partial class NewColumnsOnTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PerformedBy",
                schema: "zabota_analyses",
                table: "Talons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceLimits",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Units",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BioMaterial",
                schema: "zabota_analyses",
                table: "AnalysesTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerformedBy",
                schema: "zabota_analyses",
                table: "Talons");

            migrationBuilder.DropColumn(
                name: "ReferenceLimits",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.DropColumn(
                name: "Units",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.DropColumn(
                name: "Doctor",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses");

            migrationBuilder.DropColumn(
                name: "BioMaterial",
                schema: "zabota_analyses",
                table: "AnalysesTypes");
        }
    }
}
