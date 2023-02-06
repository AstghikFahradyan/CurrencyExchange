using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Currencyexchange.Migrations
{
    /// <inheritdoc />
    public partial class EFCoreCodeFirstSampleModelsTransactionContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfTransaction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExchangeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeValue = table.Column<float>(type: "real", nullable: false),
                    AmountFor = table.Column<float>(type: "real", nullable: false),
                    AmountTo = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
