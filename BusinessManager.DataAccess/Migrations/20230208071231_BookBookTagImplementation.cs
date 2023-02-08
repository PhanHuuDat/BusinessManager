using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessManager.DataAccess.Migrations
{
    public partial class BookBookTagImplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBookTag");

            migrationBuilder.CreateTable(
                name: "BookBookTags",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookTags", x => new { x.BookId, x.BookTagId });
                    table.ForeignKey(
                        name: "FK_BookBookTags_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookTags_BookTag_BookTagId",
                        column: x => x.BookTagId,
                        principalTable: "BookTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBookTags_BookTagId",
                table: "BookBookTags",
                column: "BookTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBookTags");

            migrationBuilder.CreateTable(
                name: "BookBookTag",
                columns: table => new
                {
                    BookTagsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookTag", x => new { x.BookTagsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_BookBookTag_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookTag_BookTag_BookTagsId",
                        column: x => x.BookTagsId,
                        principalTable: "BookTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBookTag_BooksId",
                table: "BookBookTag",
                column: "BooksId");
        }
    }
}
