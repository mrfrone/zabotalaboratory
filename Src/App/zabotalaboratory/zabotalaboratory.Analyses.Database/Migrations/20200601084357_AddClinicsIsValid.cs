using Microsoft.EntityFrameworkCore.Migrations;

namespace zabotalaboratory.Analyses.Database.Migrations
{
    public partial class AddClinicsIsValid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysesResult_LaboratoryAnalysesTests_LaboratoryAnalysesTe~",
                schema: "zabota_analyses",
                table: "AnalysesResult");

            migrationBuilder.DropForeignKey(
                name: "FK_Talons_AnalysesTypes_AnalysesTypeId",
                schema: "zabota_analyses",
                table: "Talons");

            migrationBuilder.AlterColumn<int>(
                name: "AnalysesTypeId",
                schema: "zabota_analyses",
                table: "Talons",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatronymicName",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "zabota_analyses",
                table: "Clinics",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                schema: "zabota_analyses",
                table: "Clinics",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "zabota_analyses",
                table: "AnalysesTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LaboratoryAnalysesTestsId",
                schema: "zabota_analyses",
                table: "AnalysesResult",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysesResult_LaboratoryAnalysesTests_LaboratoryAnalysesTe~",
                schema: "zabota_analyses",
                table: "AnalysesResult",
                column: "LaboratoryAnalysesTestsId",
                principalSchema: "zabota_analyses",
                principalTable: "LaboratoryAnalysesTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Talons_AnalysesTypes_AnalysesTypeId",
                schema: "zabota_analyses",
                table: "Talons",
                column: "AnalysesTypeId",
                principalSchema: "zabota_analyses",
                principalTable: "AnalysesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysesResult_LaboratoryAnalysesTests_LaboratoryAnalysesTe~",
                schema: "zabota_analyses",
                table: "AnalysesResult");

            migrationBuilder.DropForeignKey(
                name: "FK_Talons_AnalysesTypes_AnalysesTypeId",
                schema: "zabota_analyses",
                table: "Talons");

            migrationBuilder.DropColumn(
                name: "IsValid",
                schema: "zabota_analyses",
                table: "Clinics");

            migrationBuilder.AlterColumn<int>(
                name: "AnalysesTypeId",
                schema: "zabota_analyses",
                table: "Talons",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PatronymicName",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "zabota_analyses",
                table: "Clinics",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "zabota_analyses",
                table: "AnalysesTypes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "LaboratoryAnalysesTestsId",
                schema: "zabota_analyses",
                table: "AnalysesResult",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysesResult_LaboratoryAnalysesTests_LaboratoryAnalysesTe~",
                schema: "zabota_analyses",
                table: "AnalysesResult",
                column: "LaboratoryAnalysesTestsId",
                principalSchema: "zabota_analyses",
                principalTable: "LaboratoryAnalysesTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Talons_AnalysesTypes_AnalysesTypeId",
                schema: "zabota_analyses",
                table: "Talons",
                column: "AnalysesTypeId",
                principalSchema: "zabota_analyses",
                principalTable: "AnalysesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
