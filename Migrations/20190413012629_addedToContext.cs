using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RCDT.Migrations
{
    public partial class addedToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChessBoardMoveLog",
                columns: table => new
                {
                    MoveNumber = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TaskSessionID = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    dateTime = table.Column<DateTime>(nullable: false),
                    BoardState = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChessBoardMoveLog", x => x.MoveNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChessBoardMoveLog");
        }
    }
}
