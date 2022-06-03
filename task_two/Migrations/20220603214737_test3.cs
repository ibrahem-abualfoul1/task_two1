using Microsoft.EntityFrameworkCore.Migrations;

namespace task_two.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlProdact",
                table: "prodacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlProdact",
                table: "prodacts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
