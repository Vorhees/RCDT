using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RCDT.Migrations
{
    public partial class Stable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatLog",
                table: "ChatLog");

            migrationBuilder.AlterColumn<int>(
                name: "TaskSessionId",
                table: "ChatLog",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "ChatLog",
                nullable: false)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatLog",
                table: "ChatLog",
                column: "MessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatLog",
                table: "ChatLog");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "ChatLog");

            migrationBuilder.AlterColumn<int>(
                name: "TaskSessionId",
                table: "ChatLog",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatLog",
                table: "ChatLog",
                column: "TaskSessionId");
        }
    }
}
