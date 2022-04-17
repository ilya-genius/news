using Microsoft.EntityFrameworkCore.Migrations;

namespace News.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PieceOfNews",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceOfNews", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PieceOfNewsID = table.Column<int>(type: "int", nullable: false),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pictures_PieceOfNews_PieceOfNewsID",
                        column: x => x.PieceOfNewsID,
                        principalTable: "PieceOfNews",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subtitles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PieceOfNewsID = table.Column<int>(type: "int", nullable: false),
                    subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtitles", x => x.id);
                    table.ForeignKey(
                        name: "FK_Subtitles_PieceOfNews_PieceOfNewsID",
                        column: x => x.PieceOfNewsID,
                        principalTable: "PieceOfNews",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PieceOfNewsID",
                table: "Pictures",
                column: "PieceOfNewsID");

            migrationBuilder.CreateIndex(
                name: "IX_Subtitles_PieceOfNewsID",
                table: "Subtitles",
                column: "PieceOfNewsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Subtitles");

            migrationBuilder.DropTable(
                name: "PieceOfNews");
        }
    }
}
