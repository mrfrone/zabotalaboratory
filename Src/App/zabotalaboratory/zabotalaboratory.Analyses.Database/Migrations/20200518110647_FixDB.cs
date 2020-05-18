using Microsoft.EntityFrameworkCore.Migrations;

namespace zabotalaboratory.Analyses.Database.Migrations
{
    public partial class FixDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryAnalysesTests_AnalysesTypes_AnalysesTypeId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryAnalysesTests_AnalysesTypeId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.DropColumn(
                name: "AnalysesTypeId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.AddColumn<int>(
                name: "AnalysesTypesId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryAnalysesTests_AnalysesTypesId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                column: "AnalysesTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryAnalysesTests_AnalysesTypes_AnalysesTypesId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                column: "AnalysesTypesId",
                principalSchema: "zabota_analyses",
                principalTable: "AnalysesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryAnalysesTests_AnalysesTypes_AnalysesTypesId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryAnalysesTests_AnalysesTypesId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.DropColumn(
                name: "AnalysesTypesId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.AddColumn<int>(
                name: "AnalysesTypeId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryAnalysesTests_AnalysesTypeId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                column: "AnalysesTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryAnalysesTests_AnalysesTypes_AnalysesTypeId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                column: "AnalysesTypeId",
                principalSchema: "zabota_analyses",
                principalTable: "AnalysesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
