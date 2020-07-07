using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonDiaryAPI.Migrations
{
    public partial class migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Diarys",
                columns: table => new
                {
                    diaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    dateTime = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diarys", x => x.diaryId);
                    table.ForeignKey(
                        name: "FK_Diarys_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diarys_userId",
                table: "Diarys",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diarys");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
