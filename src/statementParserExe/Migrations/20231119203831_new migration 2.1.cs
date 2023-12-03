using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace statementParserExe.Migrations
{
    public partial class newmigration21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "FinancialStatements",
                newName: "ValueDate");

            migrationBuilder.RenameColumn(
                name: "ValueDat",
                table: "FinancialStatements",
                newName: "StatementDate");

            migrationBuilder.AlterColumn<double>(
                name: "DebitAmount",
                table: "FinancialStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "CreditAmount",
                table: "FinancialStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "ClosingBalance",
                table: "FinancialStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValueDate",
                table: "FinancialStatements",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "StatementDate",
                table: "FinancialStatements",
                newName: "ValueDat");

            migrationBuilder.AlterColumn<long>(
                name: "DebitAmount",
                table: "FinancialStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "CreditAmount",
                table: "FinancialStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "ClosingBalance",
                table: "FinancialStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
