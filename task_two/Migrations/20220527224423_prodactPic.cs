using Microsoft.EntityFrameworkCore.Migrations;

namespace task_two.Migrations
{
    public partial class prodactPic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlProdact",
                table: "prodacts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlProdact",
                table: "prodacts");
        }
    }
}
