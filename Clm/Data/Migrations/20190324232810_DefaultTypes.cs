using Microsoft.EntityFrameworkCore.Migrations;

namespace Clm.Data.Migrations
{
    public partial class DefaultTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "CodeId", "IsEnabled", "Name" },
                values: new object[] { 1, true, "Global project" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "CodeId", "IsEnabled", "Name" },
                values: new object[] { 2, true, "Local project" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "CodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "CodeId",
                keyValue: 2);
        }
    }
}
