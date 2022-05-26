using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace task_two.Migrations
{
    public partial class tranaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountidId",
                table: "transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBill",
                table: "transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "activebill",
                table: "transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DateBill",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "activebill",
                table: "transactions");
        }
    }
}
