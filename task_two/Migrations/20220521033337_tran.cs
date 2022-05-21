using Microsoft.EntityFrameworkCore.Migrations;

namespace task_two.Migrations
{
    public partial class tran : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameBill",
                table: "transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "transactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "idbill",
                table: "transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "NameBill",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "idbill",
                table: "transactions");
        }
    }
}
