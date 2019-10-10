using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lendit.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loggers",
                columns: table => new
                {
                    LoggerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ErrorType = table.Column<string>(nullable: true),
                    ErrorDate = table.Column<DateTime>(nullable: false),
                    ErrorDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loggers", x => x.LoggerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserHash = table.Column<string>(nullable: false),
                    UserHashEx = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    AccountNo = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    CreditScore = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserHash);
                });

            migrationBuilder.CreateTable(
                name: "Eligibilities",
                columns: table => new
                {
                    EligibilityId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserHash = table.Column<string>(nullable: true),
                    BVN = table.Column<string>(nullable: true),
                    NIN = table.Column<string>(nullable: true),
                    VCN = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eligibilities", x => x.EligibilityId);
                    table.ForeignKey(
                        name: "FK_Eligibilities_Users_UserHash",
                        column: x => x.UserHash,
                        principalTable: "Users",
                        principalColumn: "UserHash",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LenderBorrowerTransactions",
                columns: table => new
                {
                    LenderBorrowerTransactionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    LenderHash = table.Column<string>(nullable: true),
                    BorrowHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LenderBorrowerTransactions", x => x.LenderBorrowerTransactionId);
                    table.ForeignKey(
                        name: "FK_LenderBorrowerTransactions_Users_BorrowHash",
                        column: x => x.BorrowHash,
                        principalTable: "Users",
                        principalColumn: "UserHash",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LenderBorrowerTransactions_Users_LenderHash",
                        column: x => x.LenderHash,
                        principalTable: "Users",
                        principalColumn: "UserHash",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LenderPools",
                columns: table => new
                {
                    LenderPoolId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LenderHash = table.Column<string>(nullable: true),
                    InterestRate = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LenderPools", x => x.LenderPoolId);
                    table.ForeignKey(
                        name: "FK_LenderPools_Users_LenderHash",
                        column: x => x.LenderHash,
                        principalTable: "Users",
                        principalColumn: "UserHash",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionEntities",
                columns: table => new
                {
                    TransactionEntityId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    UserHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionEntities", x => x.TransactionEntityId);
                    table.ForeignKey(
                        name: "FK_TransactionEntities_Users_UserHash",
                        column: x => x.UserHash,
                        principalTable: "Users",
                        principalColumn: "UserHash",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    WalletId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WalletHash = table.Column<string>(nullable: true),
                    PrivateKey = table.Column<string>(nullable: true),
                    PublicKey = table.Column<string>(nullable: true),
                    Balance = table.Column<string>(nullable: true),
                    UserHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.WalletId);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserHash",
                        column: x => x.UserHash,
                        principalTable: "Users",
                        principalColumn: "UserHash",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eligibilities_UserHash",
                table: "Eligibilities",
                column: "UserHash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LenderBorrowerTransactions_BorrowHash",
                table: "LenderBorrowerTransactions",
                column: "BorrowHash");

            migrationBuilder.CreateIndex(
                name: "IX_LenderBorrowerTransactions_LenderHash",
                table: "LenderBorrowerTransactions",
                column: "LenderHash");

            migrationBuilder.CreateIndex(
                name: "IX_LenderPools_LenderHash",
                table: "LenderPools",
                column: "LenderHash");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionEntities_UserHash",
                table: "TransactionEntities",
                column: "UserHash");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserHash",
                table: "Wallets",
                column: "UserHash",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eligibilities");

            migrationBuilder.DropTable(
                name: "LenderBorrowerTransactions");

            migrationBuilder.DropTable(
                name: "LenderPools");

            migrationBuilder.DropTable(
                name: "Loggers");

            migrationBuilder.DropTable(
                name: "TransactionEntities");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
