using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Infrastructure.Migrations
{
    public partial class UpdateNullableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Limit_ObjectType_ObjectTypeId",
                table: "Limit");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectTypeId",
                table: "Limit",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Limit_ObjectType_ObjectTypeId",
                table: "Limit",
                column: "ObjectTypeId",
                principalTable: "ObjectType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Limit_ObjectType_ObjectTypeId",
                table: "Limit");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectTypeId",
                table: "Limit",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Limit_ObjectType_ObjectTypeId",
                table: "Limit",
                column: "ObjectTypeId",
                principalTable: "ObjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
