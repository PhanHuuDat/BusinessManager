using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessManager.DataAccess.Migrations
{
    public partial class ChangeBookSizeinBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Size_BookSizeId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Cost");

            migrationBuilder.RenameColumn(
                name: "BookSizeId",
                table: "Book",
                newName: "SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_BookSizeId",
                table: "Book",
                newName: "IX_Book_SizeId");

            migrationBuilder.CreateTable(
                name: "Import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Import", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Import_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Import_BookId",
                table: "Import",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Size_SizeId",
                table: "Book",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Size_SizeId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Import");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "Book",
                newName: "BookSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_SizeId",
                table: "Book",
                newName: "IX_Book_BookSizeId");

            migrationBuilder.CreateTable(
                name: "Cost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ImportDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cost_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cost_BookId",
                table: "Cost",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Size_BookSizeId",
                table: "Book",
                column: "BookSizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
