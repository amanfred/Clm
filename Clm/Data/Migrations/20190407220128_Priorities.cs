using Microsoft.EntityFrameworkCore.Migrations;

namespace Clm.Data.Migrations
{
    public partial class Priorities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Severities",
                keyColumn: "CodeId",
                keyValue: 6);

            migrationBuilder.AddColumn<int>(
                name: "PriorityCodeId",
                table: "Units",
                nullable: false,
                defaultValue: 100);

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    CodeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.CodeId);
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "CodeId", "IsEnabled", "Name" },
                values: new object[,]
                {
                    { 1, true, "Must have" },
                    { 2, true, "Should have" },
                    { 3, true, "Could have" },
                    { 4, true, "Will not have" },
                    { 100, true, "None" }
                });

            migrationBuilder.InsertData(
                table: "Severities",
                columns: new[] { "CodeId", "IsEnabled", "Name" },
                values: new object[] { 100, true, "None" });

            migrationBuilder.CreateIndex(
                name: "IX_Units_PriorityCodeId",
                table: "Units",
                column: "PriorityCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Priorities_PriorityCodeId",
                table: "Units",
                column: "PriorityCodeId",
                principalTable: "Priorities",
                principalColumn: "CodeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Priorities_PriorityCodeId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropIndex(
                name: "IX_Units_PriorityCodeId",
                table: "Units");

            migrationBuilder.DeleteData(
                table: "Severities",
                keyColumn: "CodeId",
                keyValue: 100);

            migrationBuilder.DropColumn(
                name: "PriorityCodeId",
                table: "Units");

            migrationBuilder.InsertData(
                table: "Severities",
                columns: new[] { "CodeId", "IsEnabled", "Name" },
                values: new object[] { 6, true, "None" });
        }
    }
}
