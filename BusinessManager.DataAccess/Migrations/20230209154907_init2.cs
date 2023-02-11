using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessManager.DataAccess.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Book_BookTagsId",
                table: "BookTag");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Tag_BookTagsId1",
                table: "BookTag");

            migrationBuilder.RenameColumn(
                name: "BookTagsId1",
                table: "BookTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "BookTagsId",
                table: "BookTag",
                newName: "BooksId");

            migrationBuilder.RenameIndex(
                name: "IX_BookTag_BookTagsId1",
                table: "BookTag",
                newName: "IX_BookTag_TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Book_BooksId",
                table: "BookTag",
                column: "BooksId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Tag_TagsId",
                table: "BookTag",
                column: "TagsId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Book_BooksId",
                table: "BookTag");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Tag_TagsId",
                table: "BookTag");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "BookTag",
                newName: "BookTagsId1");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "BookTag",
                newName: "BookTagsId");

            migrationBuilder.RenameIndex(
                name: "IX_BookTag_TagsId",
                table: "BookTag",
                newName: "IX_BookTag_BookTagsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Book_BookTagsId",
                table: "BookTag",
                column: "BookTagsId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Tag_BookTagsId1",
                table: "BookTag",
                column: "BookTagsId1",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
