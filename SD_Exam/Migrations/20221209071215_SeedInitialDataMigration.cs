using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SDExam.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "ID", "Amount", "Description", "Dose", "Title" },
                values: new object[,]
                {
                    { 1, 100, "When headache", 2.5, "Analgin" },
                    { 2, 200, "Good for blood", 5.0, "Varfaryn" },
                    { 3, 50, "When cold", 0.10000000000000001, "Nurofen" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
