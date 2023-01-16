using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessManager.DataAccess.Migrations
{
    public partial class UpdateBookBookTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookTag_BookTagId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookTagId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookTagId",
                table: "Book");

            migrationBuilder.CreateTable(
                name: "BookBookTag",
                columns: table => new
                {
                    BookTagsId = table.Column<int>(type: "int", nullable: false),
                    BooksID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookTag", x => new { x.BookTagsId, x.BooksID });
                    table.ForeignKey(
                        name: "FK_BookBookTag_Book_BooksID",
                        column: x => x.BooksID,
                        principalTable: "Book",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookTag_BookTag_BookTagsId",
                        column: x => x.BookTagsId,
                        principalTable: "BookTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBookTag_BooksID",
                table: "BookBookTag",
                column: "BooksID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBookTag");

            migrationBuilder.AddColumn<int>(
                name: "BookTagId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookTagId",
                table: "Book",
                column: "BookTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookTag_BookTagId",
                table: "Book",
                column: "BookTagId",
                principalTable: "BookTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
