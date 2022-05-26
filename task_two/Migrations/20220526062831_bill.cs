using Microsoft.EntityFrameworkCore.Migrations;

namespace task_two.Migrations
{
    public partial class bill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discounte",
                table: "bills");

            migrationBuilder.DropColumn(
                name: "Numberitems",
                table: "bills");

            migrationBuilder.AddColumn<int>(
                name: "IdProdactTransIdProdact",
                table: "bills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_regester",
                table: "bills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "bills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "activebill",
                table: "bills",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Id_regester",
                table: "bills");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "bills");

            migrationBuilder.DropColumn(
                name: "activebill",
                table: "bills");

            migrationBuilder.AddColumn<int>(
                name: "Discounte",
                table: "bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Numberitems",
                table: "bills",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
