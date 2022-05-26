using Microsoft.EntityFrameworkCore.Migrations;

namespace task_two.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartProdactTransIdProdact = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.id);
                    table.ForeignKey(
                        name: "FK_carts_prodacts_CartProdactTransIdProdact",
                        column: x => x.CartProdactTransIdProdact,
                        principalTable: "prodacts",
                        principalColumn: "IdProdact",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carts_CartProdactTransIdProdact",
                table: "carts",
                column: "CartProdactTransIdProdact");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carts");
        }
    }
}
