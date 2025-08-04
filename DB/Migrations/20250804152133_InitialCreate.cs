using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdentityDocument = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdentityDocument);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    NumberAccount = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    AccountType = table.Column<byte>(type: "tinyint", precision: 12, scale: 2, nullable: false),
                    InitialBalance = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ClientIdentityDocument = table.Column<string>(type: "nvarchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.NumberAccount);
                    table.ForeignKey(
                        name: "FK_Accounts_Clients_ClientIdentityDocument",
                        column: x => x.ClientIdentityDocument,
                        principalTable: "Clients",
                        principalColumn: "IdentityDocument");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeMovement = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Sald = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    AccountNumberAccount = table.Column<string>(type: "nvarchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountNumberAccount",
                        column: x => x.AccountNumberAccount,
                        principalTable: "Accounts",
                        principalColumn: "NumberAccount");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientIdentityDocument",
                table: "Accounts",
                column: "ClientIdentityDocument");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountNumberAccount",
                table: "Transactions",
                column: "AccountNumberAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
