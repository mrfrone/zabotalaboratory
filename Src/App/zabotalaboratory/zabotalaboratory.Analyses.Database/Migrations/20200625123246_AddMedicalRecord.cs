using Microsoft.EntityFrameworkCore.Migrations;

namespace zabotalaboratory.Analyses.Database.Migrations
{
    public partial class AddMedicalRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                schema: "zabota_analyses",
                table: "Gender",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "zabota_analyses",
                table: "Gender",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "MedicalRecord",
                schema: "zabota_analyses",
                columns: table => new
                {
                    LaboratoryAnalysesId = table.Column<int>(nullable: false),
                    InsuranceName = table.Column<string>(nullable: true),
                    PolicyNumber = table.Column<string>(nullable: true),
                    SnilsNumber = table.Column<string>(nullable: true),
                    PrivilegeCode = table.Column<string>(nullable: true),
                    PermanentAddress = table.Column<string>(nullable: true),
                    ActualAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PreferentialProvision = table.Column<string>(nullable: true),
                    Disability = table.Column<string>(nullable: true),
                    PlaceOfWork = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Dependent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecord", x => x.LaboratoryAnalysesId);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_LaboratoryAnalyses_LaboratoryAnalysesId",
                        column: x => x.LaboratoryAnalysesId,
                        principalSchema: "zabota_analyses",
                        principalTable: "LaboratoryAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalRecord",
                schema: "zabota_analyses");

            migrationBuilder.DropColumn(
                name: "IsValid",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                schema: "zabota_analyses",
                table: "Gender",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "zabota_analyses",
                table: "Gender",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "zabota_analyses",
                table: "Gender",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "Мужской", "M" },
                    { 2, "Женский", "F" }
                });
        }
    }
}
