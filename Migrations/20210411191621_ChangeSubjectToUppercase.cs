using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassRegister.Migrations
{
    public partial class ChangeSubjectToUppercase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "subject",
                table: "Teachers",
                newName: "Subject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Teachers",
                newName: "subject");
        }
    }
}
