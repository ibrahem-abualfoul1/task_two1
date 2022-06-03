using Microsoft.EntityFrameworkCore.Migrations;

namespace task_two.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bills_prodacts_IdProdactTransIdProdact",
                table: "bills");

            migrationBuilder.DropIndex(
                name: "IX_bills_IdProdactTransIdProdact",
                table: "bills");

            migrationBuilder.DropColumn(
                name: "IdProdactTransIdProdact",
                table: "bills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProdactTransIdProdact",
                table: "bills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bills_IdProdactTransIdProdact",
                table: "bills",
                column: "IdProdactTransIdProdact");

            migrationBuilder.AddForeignKey(
                name: "FK_bills_prodacts_IdProdactTransIdProdact",
                table: "bills",
                column: "IdProdactTransIdProdact",
                principalTable: "prodacts",
                principalColumn: "IdProdact",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
