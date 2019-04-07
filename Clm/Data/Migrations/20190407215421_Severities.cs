using Microsoft.EntityFrameworkCore.Migrations;

namespace Clm.Data.Migrations
{
    public partial class Severities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeverityCodeId",
                table: "Units",
                nullable: false,
                defaultValue: 6);

            migrationBuilder.CreateTable(
                name: "Severities",
                columns: table => new
                {
                    CodeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Severities", x => x.CodeId);
                });

            migrationBuilder.InsertData(
                table: "Severities",
                columns: new[] { "CodeId", "IsEnabled", "Name" },
                values: new object[,]
                {
                    { 1, true, "Blocker" },
                    { 2, true, "Critical" },
                    { 3, true, "Major" },
                    { 4, true, "Minor" },
                    { 5, true, "Trivial" },
                    { 6, true, "None" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_SeverityCodeId",
                table: "Units",
                column: "SeverityCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Severities_SeverityCodeId",
                table: "Units",
                column: "SeverityCodeId",
                principalTable: "Severities",
                principalColumn: "CodeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Severities_SeverityCodeId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Severities");

            migrationBuilder.DropIndex(
                name: "IX_Units_SeverityCodeId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "SeverityCodeId",
                table: "Units");
        }
    }
}
