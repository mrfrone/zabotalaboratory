using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace zabotalaboratory.Analyses.Database.Migrations
{
    public partial class AddAnalyses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnalysesTypes",
                schema: "zabota_analyses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Number1C = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysesTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryAnalyses",
                schema: "zabota_analyses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    PatronymicName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false),
                    ClinicId = table.Column<int>(nullable: false),
                    PickUpDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryAnalyses_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalSchema: "zabota_analyses",
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryAnalysesTests",
                schema: "zabota_analyses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number1C = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AnalysesTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryAnalysesTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryAnalysesTests_AnalysesTypes_AnalysesTypeId",
                        column: x => x.AnalysesTypeId,
                        principalSchema: "zabota_analyses",
                        principalTable: "AnalysesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Talons",
                schema: "zabota_analyses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnalysesTypeId = table.Column<int>(nullable: true),
                    LaboratoryAnalysesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talons_AnalysesTypes_AnalysesTypeId",
                        column: x => x.AnalysesTypeId,
                        principalSchema: "zabota_analyses",
                        principalTable: "AnalysesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Talons_LaboratoryAnalyses_LaboratoryAnalysesId",
                        column: x => x.LaboratoryAnalysesId,
                        principalSchema: "zabota_analyses",
                        principalTable: "LaboratoryAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnalysesResult",
                schema: "zabota_analyses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Result = table.Column<string>(nullable: true),
                    LaboratoryAnalysesTestsId = table.Column<int>(nullable: true),
                    TalonsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysesResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalysesResult_LaboratoryAnalysesTests_LaboratoryAnalysesTe~",
                        column: x => x.LaboratoryAnalysesTestsId,
                        principalSchema: "zabota_analyses",
                        principalTable: "LaboratoryAnalysesTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnalysesResult_Talons_TalonsId",
                        column: x => x.TalonsId,
                        principalSchema: "zabota_analyses",
                        principalTable: "Talons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "zabota_analyses",
                table: "Clinics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "14" });

            migrationBuilder.CreateIndex(
                name: "IX_AnalysesResult_LaboratoryAnalysesTestsId",
                schema: "zabota_analyses",
                table: "AnalysesResult",
                column: "LaboratoryAnalysesTestsId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysesResult_TalonsId",
                schema: "zabota_analyses",
                table: "AnalysesResult",
                column: "TalonsId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryAnalyses_ClinicId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalyses",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryAnalysesTests_AnalysesTypeId",
                schema: "zabota_analyses",
                table: "LaboratoryAnalysesTests",
                column: "AnalysesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Talons_AnalysesTypeId",
                schema: "zabota_analyses",
                table: "Talons",
                column: "AnalysesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Talons_LaboratoryAnalysesId",
                schema: "zabota_analyses",
                table: "Talons",
                column: "LaboratoryAnalysesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalysesResult",
                schema: "zabota_analyses");

            migrationBuilder.DropTable(
                name: "LaboratoryAnalysesTests",
                schema: "zabota_analyses");

            migrationBuilder.DropTable(
                name: "Talons",
                schema: "zabota_analyses");

            migrationBuilder.DropTable(
                name: "AnalysesTypes",
                schema: "zabota_analyses");

            migrationBuilder.DropTable(
                name: "LaboratoryAnalyses",
                schema: "zabota_analyses");

            migrationBuilder.DeleteData(
                schema: "zabota_analyses",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
