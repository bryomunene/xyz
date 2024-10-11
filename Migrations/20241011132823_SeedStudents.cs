using Microsoft.EntityFrameworkCore.Migrations;

namespace xyz.Migrations
{
    public partial class SeedStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "StudentId", "FirstName", "LastName", "IsEnrolled", "IsActive" },
                values: new object[,]
                {
                    { 1, "S001", "John", "Doe", true, true },
                    { 2, "S002", "Jane", "Smith", true, true },
                    { 3, "S003", "Mike", "Johnson", false, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });
        }
    }
}
