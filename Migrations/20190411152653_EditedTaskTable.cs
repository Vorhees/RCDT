using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RCDT.Migrations
{
    public partial class EditedTaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DDMT");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskSessionID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TaskType = table.Column<string>(nullable: false),
                    participantNumber = table.Column<int>(nullable: false),
                    confederateNumber = table.Column<int>(nullable: false),
                    taskReport = table.Column<string>(nullable: true),
                    taskTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskSessionID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.CreateTable(
                name: "DDMT",
                columns: table => new
                {
                    TaskSessionID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    confederateNumber = table.Column<int>(nullable: false),
                    participantNumber = table.Column<int>(nullable: false),
                    taskReport = table.Column<string>(nullable: true),
                    taskTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDMT", x => x.TaskSessionID);
                });
        }
    }
}
