using Microsoft.EntityFrameworkCore.Migrations;

namespace task_two.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactUs",
                table: "mangePages");

            migrationBuilder.DropColumn(
                name: "SocialMedia",
                table: "mangePages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactUs",
                table: "mangePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialMedia",
                table: "mangePages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
