using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassRegister.Migrations
{
    public partial class addAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "Email", "Password", "Role" },
                values: new object[] { 1, "admin@admin.pl", "adminadmin", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1);
        }
    }
}
