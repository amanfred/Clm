using Microsoft.EntityFrameworkCore.Migrations;

namespace Clm.Data.Migrations
{
    public partial class initUnitsAndTypesRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Units_TypeCodeId",
                table: "Units",
                column: "TypeCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Types_TypeCodeId",
                table: "Units",
                column: "TypeCodeId",
                principalTable: "Types",
                principalColumn: "CodeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Types_TypeCodeId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_TypeCodeId",
                table: "Units");
        }
    }
}
