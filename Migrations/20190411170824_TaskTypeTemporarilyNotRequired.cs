using Microsoft.EntityFrameworkCore.Migrations;

namespace RCDT.Migrations
{
    public partial class TaskTypeTemporarilyNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaskType",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaskType",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
