using Microsoft.EntityFrameworkCore.Migrations;

namespace Clm.Data.Migrations
{
    public partial class Statuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusCodeId",
                table: "Units",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    CodeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.CodeId);
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "CodeId", "IsEnabled", "Name" },
                values: new object[,]
                {
                    { 1, true, "Backlog" },
                    { 2, true, "To do" },
                    { 3, true, "In progress" },
                    { 4, true, "Ready to QA" },
                    { 5, true, "In test" },
                    { 6, true, "Ready to release" },
                    { 7, true, "Done" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_StatusCodeId",
                table: "Units",
                column: "StatusCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Statuses_StatusCodeId",
                table: "Units",
                column: "StatusCodeId",
                principalTable: "Statuses",
                principalColumn: "CodeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Statuses_StatusCodeId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Units_StatusCodeId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "StatusCodeId",
                table: "Units");
        }
    }
}
