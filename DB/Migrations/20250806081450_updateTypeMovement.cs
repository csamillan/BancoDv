using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class updateTypeMovement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientIdentityDocument",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ClientIdentityDocument",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ClientIdentityDocument",
                table: "Accounts");

            migrationBuilder.AlterColumn<byte>(
                name: "TypeMovement",
                table: "Transactions",
                type: "tinyint",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityDocument",
                table: "Accounts",
                type: "nvarchar(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdentityDocument",
                table: "Accounts",
                column: "IdentityDocument");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_IdentityDocument",
                table: "Accounts",
                column: "IdentityDocument",
                principalTable: "Clients",
                principalColumn: "IdentityDocument");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_IdentityDocument",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_IdentityDocument",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "TypeMovement",
                table: "Transactions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityDocument",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientIdentityDocument",
                table: "Accounts",
                type: "nvarchar(12)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientIdentityDocument",
                table: "Accounts",
                column: "ClientIdentityDocument");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientIdentityDocument",
                table: "Accounts",
                column: "ClientIdentityDocument",
                principalTable: "Clients",
                principalColumn: "IdentityDocument");
        }
    }
}
