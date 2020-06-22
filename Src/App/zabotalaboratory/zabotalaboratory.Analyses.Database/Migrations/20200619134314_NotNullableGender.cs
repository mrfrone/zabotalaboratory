using Microsoft.EntityFrameworkCore.Migrations;

namespace zabotalaboratory.Analyses.Database.Migrations
{
    public partial class NotNullableGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryAnalyses_Gender_GenderId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryAnalyses_Gender_GenderId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                column: "GenderId",
                principalSchema: "zabota_analyses",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryAnalyses_Gender_GenderId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
