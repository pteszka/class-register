using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassRegister.Migrations
{
    public partial class addAccToTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AccountId",
                table: "Teachers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AccountId",
                table: "Students",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Accounts_AccountId",
                table: "Students",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Accounts_AccountId",
                table: "Teachers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Accounts_AccountId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Accounts_AccountId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_AccountId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_AccountId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Students");
        }
    }
}
