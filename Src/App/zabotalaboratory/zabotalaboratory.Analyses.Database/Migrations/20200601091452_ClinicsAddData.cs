using Microsoft.EntityFrameworkCore.Migrations;

namespace zabotalaboratory.Analyses.Database.Migrations
{
    public partial class ClinicsAddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "zabota_analyses",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                schema: "zabota_analyses",
                table: "Clinics",
                columns: new[] { "Id", "IsValid", "Name" },
                values: new object[,]
                {
                    { 0, true, "14" },
                    { 1, true, "14а" },
                    { 2, true, "20" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "zabota_analyses",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 0);

            migrationBuilder.DeleteData(
                schema: "zabota_analyses",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "zabota_analyses",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                schema: "zabota_analyses",
                table: "Clinics",
                columns: new[] { "Id", "IsValid", "Name" },
                values: new object[] { 1, false, "14" });
        }
    }
}
