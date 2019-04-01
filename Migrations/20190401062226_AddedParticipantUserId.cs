using Microsoft.EntityFrameworkCore.Migrations;

namespace RCDT.Migrations
{
    public partial class AddedParticipantUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParticipantUserId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParticipantUserId",
                table: "AspNetUsers");
        }
    }
}
