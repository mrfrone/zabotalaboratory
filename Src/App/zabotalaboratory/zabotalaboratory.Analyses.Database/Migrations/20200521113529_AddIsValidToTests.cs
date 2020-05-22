using Microsoft.EntityFrameworkCore.Migrations;

namespace zabotalaboratory.Analyses.Database.Migrations
{
    public partial class AddIsValidToTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryAnalysesTests_AnalysesTypes_AnalysesTypesId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.DeleteData(
                schema: "zabota_analyses",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "AnalysesTypesId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "zabota_analyses",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "14");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryAnalysesTests_AnalysesTypes_AnalysesTypesId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                column: "AnalysesTypesId",
                principalSchema: "zabota_analyses",
                principalTable: "AnalysesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryAnalysesTests_AnalysesTypes_AnalysesTypesId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.DropColumn(
                name: "IsValid",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests");

            migrationBuilder.AlterColumn<int>(
                name: "AnalysesTypesId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                schema: "zabota_analyses",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Все");

            migrationBuilder.InsertData(
                schema: "zabota_analyses",
                table: "Clinics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "14" });

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
    }
}
