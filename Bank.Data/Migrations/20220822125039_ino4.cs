using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Data.Migrations
{
    public partial class ino4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Base");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Base",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Family = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NationalCode = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    BirthtDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                schema: "Base",
                columns: table => new
                {
                    BankAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CutomerId = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    TypeAccount = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    Deposite = table.Column<int>(type: "int", nullable: false),
                    Withdraw = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.BankAccountId);
                    table.ForeignKey(
                        name: "FK_BankAccount_Customer_CutomerId",
                        column: x => x.CutomerId,
                        principalSchema: "Base",
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralBank",
                schema: "Base",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    BankAccountId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    City = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralBank", x => x.BankId);
                    table.ForeignKey(
                        name: "FK_GeneralBank_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalSchema: "Base",
                        principalTable: "BankAccount",
                        principalColumn: "BankAccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralBank_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Base",
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_CutomerId",
                schema: "Base",
                table: "BankAccount",
                column: "CutomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralBank_BankAccountId",
                schema: "Base",
                table: "GeneralBank",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralBank_CustomerId",
                schema: "Base",
                table: "GeneralBank",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralBank",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "BankAccount",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Base");
        }
    }
}
