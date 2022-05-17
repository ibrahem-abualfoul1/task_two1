using Microsoft.EntityFrameworkCore.Migrations;

namespace task_two.Migrations
{
    public partial class new3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProdauct",
                table: "categories");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "IdProdauct",
                table: "categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
