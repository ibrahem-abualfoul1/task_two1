using Microsoft.EntityFrameworkCore.Migrations;

namespace task_two.Migrations
{
    public partial class testmonel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_regester",
                table: "testimonials",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_regester",
                table: "testimonials");
        }
    }
}
