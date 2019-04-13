using Microsoft.EntityFrameworkCore.Migrations;

namespace RCDT.Migrations
{
    public partial class EditTaskModelColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "taskTime",
                table: "Tasks",
                newName: "taskCreatedTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "taskCreatedTime",
                table: "Tasks",
                newName: "taskTime");
        }
    }
}
