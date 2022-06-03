using Microsoft.EntityFrameworkCore.Migrations;

namespace task_two.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_User_AccountidId",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_AccountidId",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "AccountidId",
                table: "transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountidId",
                table: "transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_transactions_AccountidId",
                table: "transactions",
                column: "AccountidId");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_User_AccountidId",
                table: "transactions",
                column: "AccountidId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
