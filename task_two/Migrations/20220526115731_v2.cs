using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace task_two.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prodacts_categories_CatigoryIdCategory",
                table: "prodacts");

            migrationBuilder.DropIndex(
                name: "IX_prodacts_CatigoryIdCategory",
                table: "prodacts");

            migrationBuilder.DropColumn(
                name: "CatigoryIdCategory",
                table: "prodacts");

            migrationBuilder.DropColumn(
                name: "Discounte",
                table: "bills");

            migrationBuilder.DropColumn(
                name: "Numberitems",
                table: "bills");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "User",
                newName: "RoleId");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddColumn<int>(
                name: "Id_regester",
                table: "testimonials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "testimonials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "messeges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SenderEmail",
                table: "messeges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameMessege",
                table: "messeges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactMessege",
                table: "messeges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: true),
                    order = table.Column<bool>(type: "bit", nullable: false),
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
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_AccountidId",
                table: "transactions",
                column: "AccountidId");

            migrationBuilder.CreateIndex(
                name: "IX_prodacts_IdCategory",
                table: "prodacts",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_bills_IdProdactTransIdProdact",
                table: "bills",
                column: "IdProdactTransIdProdact");

            migrationBuilder.CreateIndex(
                name: "IX_carts_CartProdactTransIdProdact",
                table: "carts",
                column: "CartProdactTransIdProdact");

            migrationBuilder.AddForeignKey(
                name: "FK_bills_prodacts_IdProdactTransIdProdact",
                table: "bills",
                column: "IdProdactTransIdProdact",
                principalTable: "prodacts",
                principalColumn: "IdProdact",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_prodacts_categories_IdCategory",
                table: "prodacts",
                column: "IdCategory",
                principalTable: "categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_User_AccountidId",
                table: "transactions",
                column: "AccountidId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_roles_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bills_prodacts_IdProdactTransIdProdact",
                table: "bills");

            migrationBuilder.DropForeignKey(
                name: "FK_prodacts_categories_IdCategory",
                table: "prodacts");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_User_AccountidId",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_User_roles_RoleId",
                table: "User");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_transactions_AccountidId",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_prodacts_IdCategory",
                table: "prodacts");

            migrationBuilder.DropIndex(
                name: "IX_bills_IdProdactTransIdProdact",
                table: "bills");

            migrationBuilder.DropColumn(
                name: "AccountidId",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "DateBill",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "activebill",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "Id_regester",
                table: "testimonials");

            migrationBuilder.DropColumn(
                name: "active",
                table: "testimonials");

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

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "User",
                newName: "IdRole");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatigoryIdCategory",
                table: "prodacts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "messeges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SenderEmail",
                table: "messeges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameMessege",
                table: "messeges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactMessege",
                table: "messeges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_prodacts_CatigoryIdCategory",
                table: "prodacts",
                column: "CatigoryIdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_prodacts_categories_CatigoryIdCategory",
                table: "prodacts",
                column: "CatigoryIdCategory",
                principalTable: "categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
