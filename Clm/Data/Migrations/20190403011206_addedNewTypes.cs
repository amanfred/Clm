using Microsoft.EntityFrameworkCore.Migrations;

namespace Clm.Data.Migrations
{
    public partial class addedNewTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "CodeId", "IsEnabled", "Name" },
                values: new object[] { 3, true, "Epic" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "CodeId", "IsEnabled", "Name" },
                values: new object[] { 4, true, "User story" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "CodeId", "IsEnabled", "Name" },
                values: new object[] { 5, true, "Sub-task" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "CodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "CodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "CodeId",
                keyValue: 5);
        }
    }
}
