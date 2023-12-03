using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace statementParserExe.Migrations
{
    public partial class newmigration20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialStatements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DebitAmount = table.Column<long>(type: "bigint", nullable: false),
                    CreditAmount = table.Column<long>(type: "bigint", nullable: false),
                    ReferenceNumber = table.Column<long>(type: "bigint", nullable: false),
                    ClosingBalance = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialStatements", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialStatements");
        }
    }
}
