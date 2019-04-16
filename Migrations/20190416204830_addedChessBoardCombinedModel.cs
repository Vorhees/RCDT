using Microsoft.EntityFrameworkCore.Migrations;

namespace RCDT.Migrations
{
    public partial class addedChessBoardCombinedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BoardState",
                table: "ChessBoardMoveLog",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BoardState",
                table: "ChessBoardMoveLog",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
