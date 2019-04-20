using Microsoft.EntityFrameworkCore.Migrations;

namespace RCDT.Migrations
{
    public partial class AddedNumUsersInGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumUsersInGroup",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumUsersInGroup",
                table: "Users");
        }
    }
}
