using Microsoft.EntityFrameworkCore.Migrations;

namespace task_two.Migrations
{
    public partial class category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prodacts_categories_CatigoryIdCategory",
                table: "prodacts");

            migrationBuilder.DropIndex(
                name: "IX_prodacts_CatigoryIdCategory",
                table: "prodacts");

            migrationBuilder.DropColumn(
                name: "CatigoryIdCategory",
                table: "prodacts");

            migrationBuilder.CreateIndex(
                name: "IX_prodacts_IdCategory",
                table: "prodacts",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_prodacts_categories_IdCategory",
                table: "prodacts",
                column: "IdCategory",
                principalTable: "categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prodacts_categories_IdCategory",
                table: "prodacts");

            migrationBuilder.DropIndex(
                name: "IX_prodacts_IdCategory",
                table: "prodacts");

            migrationBuilder.AddColumn<int>(
                name: "CatigoryIdCategory",
                table: "prodacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_prodacts_CatigoryIdCategory",
                table: "prodacts",
                column: "CatigoryIdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_prodacts_categories_CatigoryIdCategory",
                table: "prodacts",
                column: "CatigoryIdCategory",
                principalTable: "categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
