using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Infrastructure.Migrations
{
    public partial class UpdateForeignKeyForTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_DestinationAccountId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_SourceAccountId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_LimitTransferType_LimitId",
                table: "LimitTransferType");

            migrationBuilder.DropIndex(
                name: "IX_LimitAccountType_LimitId",
                table: "LimitAccountType");

            migrationBuilder.RenameColumn(
                name: "SourceAccountId",
                table: "Transaction",
                newName: "SourceAccountNumber");

            migrationBuilder.RenameColumn(
                name: "DestinationAccountId",
                table: "Transaction",
                newName: "DestinationAccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_SourceAccountId",
                table: "Transaction",
                newName: "IX_Transaction_SourceAccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_DestinationAccountId",
                table: "Transaction",
                newName: "IX_Transaction_DestinationAccountNumber");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Account_Number",
                table: "Account",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "Unique_LimitTransferType",
                table: "LimitTransferType",
                columns: new[] { "LimitId", "TransferTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unique_LimitAccountType",
                table: "LimitAccountType",
                columns: new[] { "LimitId", "AccountTypeId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_DestinationAccountNumber",
                table: "Transaction",
                column: "DestinationAccountNumber",
                principalTable: "Account",
                principalColumn: "Number");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_SourceAccountNumber",
                table: "Transaction",
                column: "SourceAccountNumber",
                principalTable: "Account",
                principalColumn: "Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_DestinationAccountNumber",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_SourceAccountNumber",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "Unique_LimitTransferType",
                table: "LimitTransferType");

            migrationBuilder.DropIndex(
                name: "Unique_LimitAccountType",
                table: "LimitAccountType");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Account_Number",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "SourceAccountNumber",
                table: "Transaction",
                newName: "SourceAccountId");

            migrationBuilder.RenameColumn(
                name: "DestinationAccountNumber",
                table: "Transaction",
                newName: "DestinationAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_SourceAccountNumber",
                table: "Transaction",
                newName: "IX_Transaction_SourceAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_DestinationAccountNumber",
                table: "Transaction",
                newName: "IX_Transaction_DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LimitTransferType_LimitId",
                table: "LimitTransferType",
                column: "LimitId");

            migrationBuilder.CreateIndex(
                name: "IX_LimitAccountType_LimitId",
                table: "LimitAccountType",
                column: "LimitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_DestinationAccountId",
                table: "Transaction",
                column: "DestinationAccountId",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_SourceAccountId",
                table: "Transaction",
                column: "SourceAccountId",
                principalTable: "Account",
                principalColumn: "Id");
        }
    }
}
